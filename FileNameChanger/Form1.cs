namespace FileNameChanger
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> previewChanges = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
            dgvFormat.CellClick += dgvFormat_CellClick;
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            if (fbd1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd1.SelectedPath;
                LoadFormat(fbd1.SelectedPath);
            }
        }

        public void LoadFormat(string folderPath)
        {
            dgvFormat.Columns.Clear();
            dgvFormat.Rows.Clear();
            //dgvFormat.Dock = DockStyle.Fill;

            dgvFormat.Columns.Add("MP4/MKV", "MP4/MKV Files");
            dgvFormat.Columns.Add("SRT", "SRT Files");

            dgvFormat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFormat.Columns[0].FillWeight = 50;
            dgvFormat.Columns[1].FillWeight = 50;

            dgvFormat.DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;

            dgvFormat.ColumnHeadersDefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;


            var videoFiles = Directory.GetFiles(folderPath).Where(f => Path.GetExtension(f).Equals(".mp4", StringComparison.OrdinalIgnoreCase)
                                                                    || Path.GetExtension(f).Equals(".mkv", StringComparison.OrdinalIgnoreCase)).Select(f => Path.GetFileName(f)).ToList();
            var srtFiles = Directory.GetFiles(folderPath, "*.srt").Select(f => Path.GetFileName(f)).ToList();

            int maxRows = Math.Max(videoFiles.Count, srtFiles.Count);

            for (int i = 0; i < maxRows; i++)
            {
                var rowIndex = dgvFormat.Rows.Add(
                    i < videoFiles.Count ? videoFiles[i] : "",
                    i < srtFiles.Count ? srtFiles[i] : ""
                );

                // Store original filenames in Tag
                if (i < videoFiles.Count)
                    dgvFormat.Rows[rowIndex].Cells[0].Tag = videoFiles[i];
                if (i < srtFiles.Count)
                    dgvFormat.Rows[rowIndex].Cells[1].Tag = srtFiles[i];
            }
        }

        private void chkRename_CheckedChanged(object sender, EventArgs e)
        {
            //lblIf.Visible = chkRename.Checked;
            //txtIf.Visible = chkRename.Checked;

            if (!chkRename.Checked)
                return;

            if (dgvFormat.CurrentCell == null)
                return;

            int rowIndex = dgvFormat.CurrentCell.RowIndex;
            int colIndex = dgvFormat.CurrentCell.ColumnIndex;

            var currentCell = dgvFormat.Rows[rowIndex].Cells[colIndex];
            var otherCell = dgvFormat.Rows[rowIndex].Cells[colIndex == 0 ? 1 : 0];

            if (currentCell.Value == null || otherCell.Value == null)
                return;

            string otherFileName = otherCell.Value.ToString();

            if (string.IsNullOrWhiteSpace(otherFileName))
                return;

            // Remove extension from the other file
            string otherNameWithoutExt = Path.GetFileNameWithoutExtension(otherFileName);

            // Get current file extension
            string currentExtension = Path.GetExtension(currentCell.Value.ToString());

            // Set textbox to new name
            txtRename.Text = otherNameWithoutExt + currentExtension;
        }

        private void dgvFormat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var value = dgvFormat.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    txtRename.Text = value.ToString();
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (!chkRename.Checked)
            {
                MessageBox.Show("Please tick the rename checkbox.");
                return;
            }

            if (dgvFormat.CurrentCell == null)
            {
                MessageBox.Show("Select a column (MKV or SRT) first.");
                return;
            }

            int selectedColumn = dgvFormat.CurrentCell.ColumnIndex;
            int otherColumn = selectedColumn == 0 ? 1 : 0;

            foreach (DataGridViewRow row in dgvFormat.Rows)
            {
                var currentCell = row.Cells[selectedColumn];
                var otherCell = row.Cells[otherColumn];

                if (currentCell.Value == null || otherCell.Value == null)
                    continue;

                string currentFile = currentCell.Value.ToString();
                string otherFile = otherCell.Value.ToString();

                if (string.IsNullOrWhiteSpace(currentFile) || string.IsNullOrWhiteSpace(otherFile))
                    continue;

                string newNameWithoutExt = Path.GetFileNameWithoutExtension(otherFile);
                string currentExtension = Path.GetExtension(currentFile);

                string newFileName = newNameWithoutExt + currentExtension;

                // Preview only (do not rename yet)
                currentCell.Value = newFileName;
            }

            MessageBox.Show("Preview rename completed.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvFormat.CurrentCell != null)
            {
                int rowIndex = dgvFormat.CurrentCell.RowIndex;
                int colIndex = dgvFormat.CurrentCell.ColumnIndex;

                //var originalFileName = dgvFormat.Rows[rowIndex].Cells[colIndex].Tag?.ToString();

                var cell = dgvFormat.Rows[rowIndex].Cells[colIndex];

                if (cell.Tag == null)
                {
                    MessageBox.Show("No original filename stored. Please preview rename first.");
                    return;
                }

                string originalFileName = cell.Tag.ToString();
                string folderPath = txtPath.Text;
                string originalFilePath = Path.Combine(folderPath, originalFileName);
                string newFileName = cell.Value.ToString();
                string newFilePath = Path.Combine(folderPath, newFileName);

                try
                {
                    File.Move(originalFilePath, newFilePath);
                    cell.Tag = newFileName;
                    MessageBox.Show("File renamed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error renaming file: {ex.Message}");
                }
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            string folderPath = txtPath.Text;

            if (string.IsNullOrWhiteSpace(folderPath))
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            int successCount = 0;
            int errorCount = 0;

            foreach (DataGridViewRow row in dgvFormat.Rows)
            {
                for (int col = 0; col < dgvFormat.Columns.Count; col++)
                {
                    var cell = row.Cells[col];

                    if (cell.Value == null || cell.Tag == null)
                        continue;

                    string originalFileName = cell.Tag.ToString();
                    string newFileName = cell.Value.ToString();

                    if (originalFileName == newFileName)
                        continue;

                    string originalPath = Path.Combine(folderPath, originalFileName);
                    string newPath = Path.Combine(folderPath, newFileName);

                    try
                    {
                        if (File.Exists(originalPath))
                        {
                            File.Move(originalPath, newPath);
                            cell.Tag = newFileName; // update original reference
                            successCount++;
                        }
                    }
                    catch
                    {
                        errorCount++;
                    }
                }
            }

            MessageBox.Show("Rename completed!");
        }
    }
}
