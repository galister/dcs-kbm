using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace KBM_88
{
    public sealed partial class MainForm : Form
    {
        private static readonly string[] DefaultMaps = {"Caucasus", "Nevada", "Normandy", "Persian Gulf", "Syria", "The Channel"};
        private static readonly string[] DefaultAirframes = {"A-10C_2", "AV8BNA", "F-14B", "F-16C_50", "FA-18C_hornet"};
        private static readonly string SavedGames = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Saved Games");

        private Settings _settings;
        public MainForm()
        {
            AutoScaleMode = AutoScaleMode.None;
            Font = new Font(Font.Name, (float) Math.Round(9f * 100f / CreateGraphics().DpiX), Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _settings = Settings.Load();

            foreach (var dPath in Directory.GetDirectories(SavedGames, "DCS.*"))
            {
                var dName = Path.GetFileName(dPath);
                if (dName.Length > 4)
                    cbDcsInstance.Items.Add(new Named<string>(dName, dPath));
            }

            if (!String.IsNullOrWhiteSpace(_settings.SavedGamesFolder))
            {
                for (var i = 0; i < cbDcsInstance.Items.Count; i++)
                {
                    if (cbDcsInstance.Items[i] is Named<string> s
                        && s.Name == _settings.SavedGamesFolder)
                    {
                        cbDcsInstance.SelectedIndex = i;
                        break;
                    }
                }
            }
            if (cbDcsInstance.SelectedIndex == -1 && cbDcsInstance.Items.Count > 0)
                cbDcsInstance.SelectedIndex = 0;
        }

        private void cbDcsInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDcsInstance.SelectedItem is Named<string> sgFolder)
            {
                _settings.SavedGamesFolder = sgFolder.Name;
                _settings.Save();
                
                LoadDcsInstance(sgFolder.Thing);
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            LoadKneeboardManagerFolder();
        }

        private void LoadListBoxItems(string parentPath, CheckedListBox lb, ICollection<string> selections)
        {
            lb.Items.Clear();

            foreach (var dPath in Directory.GetDirectories(parentPath))
            {
                var thing = new Named<string>(Path.GetFileName(dPath), dPath);
                
                if (thing.Name.StartsWith("bak-"))
                    continue;
                
                lb.Items.Add(thing);
                if (selections.Contains(thing.Name))
                    lb.SetItemChecked(lb.Items.Count-1, true);
            }
        }
        private void LoadComboBoxItems(string dPath, ComboBox cb, string selection)
        {
            foreach (var subPath in Directory.GetDirectories(dPath))
            {
                var thing = new Named<string>(Path.GetFileName(subPath), subPath);
                
                if (thing.Name.StartsWith("bak-"))
                    continue;
                
                cb.Items.Add(thing);
                if (thing.Name == selection)
                    cb.SelectedIndex = cb.Items.Count - 1;
            }
        }

        private static readonly Regex NicknameRegex = new Regex("^[ \\t]*\\[\\d+][ \\t]*=[ \\t]*\"([^\"]+)\",?[ \\t]*", RegexOptions.Multiline | RegexOptions.Compiled);
        private void LoadDcsInstance(string sgFolder)
        {
            var nickNamesFile = Path.Combine(sgFolder, "Config","nicknames.lua");
            if (File.Exists(nickNamesFile))
            {
                foreach (Match m in NicknameRegex.Matches(File.ReadAllText(nickNamesFile)))
                    cbCallsign.Items.Add(m.Groups[1].Value);

                if (cbCallsign.Items.Count > 0)
                    cbCallsign.SelectedIndex = 0;
            }

            LoadKneeboardManagerFolder();
        }
        

        private void LoadKneeboardManagerFolder()
        {
            var selectedMap = (cbMap.SelectedItem as Named<string>)?.Name ?? _settings.Map;
            var selectedAirframe = (cbAirframe.SelectedItem as Named<string>)?.Name ?? _settings.Airframe;
            
            cbMap.Items.Clear();
            cbAirframe.Items.Clear();

            if (cbDcsInstance.SelectedItem is Named<string> sgFolder)
            {
                var kneeboardFolder = Path.Combine(sgFolder.Thing, "KneeboardManager");
                if (Directory.Exists(kneeboardFolder))
                {
                    foreach (var dPath in Directory.GetDirectories(kneeboardFolder))
                    {
                        var dName = Path.GetFileName(dPath);
                        switch (dName)
                        {
                            case "Maps":
                                LoadComboBoxItems(dPath, cbMap, selectedMap);
                                break;
                            case "Aircraft":
                                LoadComboBoxItems(dPath, cbAirframe, selectedAirframe);
                                break;
                            case "Common":
                                LoadListBoxItems(dPath, lbCommon, _settings.CommonSelections);
                                lbCommon.Tag = dPath;
                                break;
                        }
                    }
                }

                if (cbMap.Items.Count == 0 && cbAirframe.Items.Count == 0)
                {
                    InitFolderStructure(sgFolder);
                }
            }
        }

        private void InitFolderStructure(Named<string> sgFolder)
        {
            var kneeboardFolder = Path.Combine(sgFolder.Thing, "KneeboardManager");
            var dcsKneeboardFolder = Path.Combine(sgFolder.Thing, "Kneeboard");

            Directory.CreateDirectory(Path.Combine(kneeboardFolder, "Common"));
            
            if (Directory.Exists(dcsKneeboardFolder))
            {
                foreach (var d in Directory.EnumerateDirectories(dcsKneeboardFolder))
                    Directory.CreateDirectory(Path.Combine(kneeboardFolder, "Aircraft", Path.GetFileName(d)));
            }
            else
            {
                foreach (var d in DefaultAirframes)
                    Directory.CreateDirectory(Path.Combine(kneeboardFolder, "Aircraft", Path.GetFileName(d)));
            }

            foreach (var d in DefaultMaps)
                Directory.CreateDirectory(Path.Combine(kneeboardFolder, "Maps", Path.GetFileName(d)));

            LoadKneeboardManagerFolder();
        }

        private void cbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMap.SelectedItem is Named<string> selectedMap)
            {
                if (!_settings.MapSelections.TryGetValue(selectedMap.Name, out var selections))
                    selections = new List<string>(0);
                
                LoadListBoxItems(selectedMap.Thing, lbMap, selections);
            }
        }

        private void cbAirframe_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAirframe.Items.Clear();
            
            if (cbAirframe.SelectedItem is Named<string> selectedAirframe)
            {
                if (!_settings.AirframeSelections.TryGetValue(selectedAirframe.Name, out var selections))
                    selections = new List<string>(0);
                
                LoadListBoxItems(selectedAirframe.Thing, lbAirframe, selections);
            }
        }

        private void WriteNickName(Named<string> selectedInstance)
        {
            if (cbCallsign.SelectedIndex > 0 || !String.IsNullOrWhiteSpace(cbCallsign.Text))
            {
                var nickNamesFile = Path.Combine(selectedInstance.Thing, "Config", "nicknames.lua");
                int i = 1;
                var selected = cbCallsign.SelectedItem ?? cbCallsign.Text;

                var sb = new StringBuilder();
                sb.AppendLine("nicknames = ");
                sb.AppendLine("{");
                sb.AppendLine($"    [{i}] = \"{selected}\",");
                foreach (var o in cbCallsign.Items)
                {
                    if (i > 4)
                        break;

                    if (o != selected)
                        sb.AppendLine($"    [{++i}] = \"{o}\",");
                }
                sb.AppendLine("} -- end of nicknames");

                File.WriteAllText(nickNamesFile, sb.ToString());
            }
        }

        private string CleanupTargetFolder(Named<string> selectedInstance, Named<string> selectedAirframe)
        {
            var targetFolder = Path.Combine(selectedInstance.Thing, "Kneeboard", selectedAirframe.Name);
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);
            
            var listFile = Path.Combine(targetFolder, "managed-kneeboards.json");
            if (File.Exists(listFile))
            {
                try
                {
                    var filesToClean = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(listFile));

                    foreach (var f in filesToClean)
                    {
                        var canDelete = true;
                        foreach (var c in Path.GetInvalidFileNameChars()) // don't attempt to delete if has shady characters like /
                            if (f.Contains(c))
                                canDelete = false;
                                
                        if (canDelete)
                            File.Delete(Path.Combine(targetFolder, f));
                    }
                }
                catch { /* ign */ }
                
                File.Delete(listFile);
            }
            
            var files = Directory.GetFiles(targetFolder);
            if (files.Any())
            {
                var backupFolder = $"bak-{DateTime.Now:yyyy-MMM-dd}";
                var backupPath = Path.Combine(targetFolder, backupFolder);

                if (MessageBox.Show(
                    $"Found untracked files in your Kneeboard\\{targetFolder} folder!\n\nIf you continue, these files will be moved to Kneeboard\\{selectedAirframe.Name}\\{backupFolder}!\n\nContinue?",
                    "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return null;

                if (!Directory.Exists(backupPath))
                    Directory.CreateDirectory(backupPath);

                foreach (var file in files)
                {
                    var destPath = Path.Combine(backupPath, Path.GetFileName(file));
                    if (File.Exists(destPath))
                        if (File.GetLastWriteTime(destPath) == File.GetLastWriteTime(file))
                            File.Delete(file);
                        else
                        {
                            File.Move(file, Path.Combine(
                                Path.GetDirectoryName(destPath) ?? throw new InvalidOperationException(),
                                Path.GetFileNameWithoutExtension(destPath) + Guid.NewGuid().ToString("B").Split('-')[0] + '.' + Path.GetExtension(destPath)
                            ));
                        }
                    else
                        File.Move(file, destPath);
                    
                }
            }

            return targetFolder;
        }

        private bool VerifyDcsBinFolder(Named<string> selectedInstance)
        {
            if (_settings.DcsBinFolders == null)
                _settings.DcsBinFolders = new Dictionary<string, string>();
            
            if (_settings.DcsBinFolders.TryGetValue(selectedInstance.Name, out var binPath))
                if (File.Exists(binPath))
                    return true;
            
            while (true)
            {
                if (MessageBox.Show($"Please show me the DCS.exe of your {selectedInstance.Name} installation!", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
                
                if (openFileDialog1.ShowDialog(this) != DialogResult.OK)
                    return false;

                var dcsExe = openFileDialog1.FileName;
                if (File.Exists(dcsExe))
                {
                    _settings.DcsBinFolders[selectedInstance.Name] = dcsExe;
                    return true;
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbDcsInstance.SelectedItem is Named<string> selectedInstance
                && cbAirframe.SelectedItem is Named<string> selectedAirframe
                && cbMap.SelectedItem is Named<string> selectedMap)
            {
                if (sender == button1)
                    if (!VerifyDcsBinFolder(selectedInstance))
                        return;

                var targetFolder = CleanupTargetFolder(selectedInstance, selectedAirframe);
                if (targetFolder == null)
                    return;

                _settings.Airframe = selectedAirframe.Name;
                _settings.Map = selectedMap.Name;

                if (_settings.MapSelections.TryGetValue(selectedMap.Name, out var mapSelections))
                    mapSelections.Clear();
                else
                    _settings.MapSelections[selectedMap.Name] = mapSelections = new List<string>();
                
                if (_settings.AirframeSelections.TryGetValue(selectedAirframe.Name, out var airframeSelections))
                    airframeSelections.Clear();
                else
                    _settings.AirframeSelections[selectedAirframe.Name] = airframeSelections = new List<string>();

                WriteNickName(selectedInstance);
                var fileNames = new HashSet<string>();
                
                foreach (var checkedItem in lbMap.CheckedItems)
                {
                    if (checkedItem is Named<string> subFolder)
                    {
                        mapSelections.Add(subFolder.Name);
                        
                        foreach (var fPath in Directory.GetFiles(subFolder.Thing))
                        {
                            var fName = Path.GetFileName(fPath);
                            fileNames.Add(fName);
                            File.Copy(fPath, Path.Combine(targetFolder, fName), true);
                        }
                    }
                }
                
                foreach (var checkedItem in lbAirframe.CheckedItems)
                {
                    if (checkedItem is Named<string> subFolder)
                    {
                        airframeSelections.Add(subFolder.Name);
                        
                        foreach (var fPath in Directory.GetFiles(subFolder.Thing))
                        {
                            var fName = Path.GetFileName(fPath);
                            fileNames.Add(fName);
                            File.Copy(fPath, Path.Combine(targetFolder, fName), true);
                        }
                    }
                }
                
                _settings.CommonSelections.Clear();
                foreach (var checkedItem in lbCommon.CheckedItems)
                {
                    if (checkedItem is Named<string> subFolder)
                    {
                        _settings.CommonSelections.Add(subFolder.Name);
                        
                        foreach (var fPath in Directory.GetFiles(subFolder.Thing))
                        {
                            var fName = Path.GetFileName(fPath);
                            fileNames.Add(fName);
                            File.Copy(fPath, Path.Combine(targetFolder, fName), true);
                        }
                    }
                }
                _settings.Save();
                File.WriteAllText(Path.Combine(targetFolder, "managed-kneeboards.json"), JsonConvert.SerializeObject(fileNames));

                if (sender == button1)
                {
                    var exePath = _settings.DcsBinFolders[selectedInstance.Name];
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        WorkingDirectory = Path.GetDirectoryName(exePath) ?? throw new InvalidOperationException()
                    });
                }

                Application.Exit();
            }
            else
            {
                MessageBox.Show("Need to select: DCS Instance, Map, Airframe!");
            }
        }

        private void LbHandleRightClick(CheckedListBox lb, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var i = lb.IndexFromPoint(e.Location);
                if (i >= 0)
                {
                    lb.SelectedIndex = i;
                    contextMenuStrip1.Tag = lb;
                    contextMenuStrip1.Show(lb, e.Location, ToolStripDropDownDirection.BelowRight);
                }
                else
                {
                    contextMenuStrip2.Tag = lb;
                    contextMenuStrip2.Show(lb, e.Location, ToolStripDropDownDirection.BelowRight);
                }
            }
        }

        private void lbMap_MouseUp(object sender, MouseEventArgs e)
        {
            LbHandleRightClick(lbMap, e);
        }

        private void lbAirframe_MouseUp(object sender, MouseEventArgs e)
        {
            LbHandleRightClick(lbAirframe, e);
        }

        private void lbCommon_MouseUp(object sender, MouseEventArgs e)
        {
            LbHandleRightClick(lbCommon, e);
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parent = contextMenuStrip1.Tag as CheckedListBox;

            var rootFolder = parent == lbAirframe
                ? (cbAirframe.SelectedItem as Named<string>)?.Thing
                : parent == lbMap
                    ? (cbMap.SelectedItem as Named<string>)?.Thing
                    : (lbCommon.SelectedItem as Named<string>)?.Thing;

            Debug.Assert(parent != null, nameof(parent) + " != null");
            var selectedFolder = (parent.SelectedItem as Named<string>)?.Thing;

            Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(
                    rootFolder ?? throw new InvalidOperationException(), 
                    selectedFolder ?? throw new InvalidOperationException()
                    ),
                UseShellExecute = true
            });
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parent = contextMenuStrip1.Tag as CheckedListBox;

            Debug.Assert(parent != null, nameof(parent) + " != null");
            var selectedFolder = (parent.SelectedItem as Named<string>);
            if (selectedFolder == null)
                return;
            
            var newDir = Interaction.InputBox($"Enter new name for category '{selectedFolder.Name}'.\n\nNumbers in the front are for ordering purposes.", "Rename Category", selectedFolder.Name);
            if (String.IsNullOrWhiteSpace(newDir) || newDir == selectedFolder.Name)
                return;

            var baseDir = parent == lbAirframe
                ? (cbAirframe.SelectedItem as Named<string>)?.Thing
                : parent == lbMap
                    ? (cbMap.SelectedItem as Named<string>)?.Thing
                    : (string) lbCommon.Tag;

            var path = validateNewDirPath(baseDir, newDir);
            if (path == null)
                return;
            
            Directory.Move(selectedFolder.Thing, path);
            
            parent.Items.RemoveAt(parent.SelectedIndex);
            lbAddItem(parent, new Named<string>(newDir, path));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parent = contextMenuStrip1.Tag as CheckedListBox;

            Debug.Assert(parent != null, nameof(parent) + " != null");
            var selectedFolder = (parent.SelectedItem as Named<string>);
            if (selectedFolder == null)
                return;

            var result = MessageBox.Show($"Permanently delete '{selectedFolder.Name}', including ALL contents?\n\nSelect 'No' if you just want it hidden from this list!","", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Directory.Delete(selectedFolder.Thing, true);
                parent.Items.RemoveAt(parent.SelectedIndex);
            }
            else if (result == DialogResult.No)
            {
                var newName = $"bak-{Guid.NewGuid().ToString("D").Split('-')[0]}-{selectedFolder.Name}";
                
                Directory.Move(
                    selectedFolder.Thing, 
                    Path.Combine(
                        Path.GetDirectoryName(selectedFolder.Thing) ?? throw new InvalidOperationException(), 
                        newName)
                    );
                parent.Items.RemoveAt(parent.SelectedIndex);
            }
            
        }
        
        private void lbAddItem(CheckedListBox parent, Named<string> newItem)
        {
            var items = new List<(Named<string>, bool)>(parent.Items.Count + 1)
            {
                (newItem, false)
            };
            for (var i = 0; i < parent.Items.Count; i++)
                items.Add((parent.Items[i] as Named<string>, parent.GetItemChecked(i)));
            
            parent.Items.Clear();
            foreach (var (item, check) in items.OrderBy(x => x.Item1.Name))
            {
                parent.Items.Add(item);
                parent.SetItemChecked(parent.Items.Count-1, check);
            }
        }

        private string validateNewDirPath(string baseDir, string newDir)
        {
            if (baseDir == null)
            {
                MessageBox.Show("Please select Map / Aircraft first!");
                return null;
            }
            
            foreach (var c in Path.GetInvalidFileNameChars())
                if (newDir.Contains(c))
                {
                    MessageBox.Show($"Windows folder names cannot contain character: {c}");
                    return null;
                }
            
            var path = Path.Combine(baseDir, newDir);

            if (Directory.Exists(path))
            {
                MessageBox.Show("Already exists.");
                return null;
            }

            return path;
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newDir = Interaction.InputBox("Enter name for new category.\n\nNumbers in the front are for ordering purposes.", "New Category", "1 Base");
            if (String.IsNullOrWhiteSpace(newDir))
                return;

            var parent = contextMenuStrip2.Tag as CheckedListBox;

            var baseDir = parent == lbAirframe
                ? (cbAirframe.SelectedItem as Named<string>)?.Thing
                : parent == lbMap
                    ? (cbMap.SelectedItem as Named<string>)?.Thing
                    : (string) lbCommon.Tag;

            var path = validateNewDirPath(baseDir, newDir);
            if (path == null)
                return;
            
            Directory.CreateDirectory(path);
            lbAddItem(parent, new Named<string>(newDir, path));
        }
    }
}