using BirdAviaryManagement.Models;
using BirdAviaryManagement.Services;

namespace BirdAviaryManagement;

public partial class Form1 : Form
{
    private DatabaseService databaseService =
        new DatabaseService();

    private TextBox txtBirdName;
    private TextBox txtHatchYear;
    private TextBox txtSearchBird;
    private TextBox txtRingId;
    private TextBox txtColor;

    private ComboBox cmbBirdType;
    private ComboBox cmbStatus;

    private CheckBox chkForSale;

    private Button btnAddBird;
    private Button btnRemoveBird;
    private Button btnSearchBird;
    private Button btnSortBirds;
    private Button btnGenerateBirds;

    private DataGridView dgvBirds;

    private Label lblBirdCount;
    private Label lblAverageAge;
    private Label lblBirdsForSale;

    public Form1()
    {
        InitializeComponent();

        this.Text =
            "Bird Aviary Management";

        this.Size =
            new Size(1700, 1000);

        this.StartPosition =
            FormStartPosition.CenterScreen;

        this.BackColor =
            Color.FromArgb(235, 242, 250);

        this.Font =
            new Font("Segoe UI", 11);

        Label title = new Label();

        title.Text =
            "Bird Aviary Management";

        title.Font =
            new Font(
                "Segoe UI",
                34,
                FontStyle.Bold
            );

        title.ForeColor =
            Color.DarkBlue;

        title.AutoSize = true;

        title.Location =
            new Point(430, 20);

        Controls.Add(title);

        Panel leftPanel = new Panel();

        leftPanel.BackColor =
            Color.White;

        leftPanel.Size =
            new Size(420, 720);

        leftPanel.Location =
            new Point(30, 120);

        leftPanel.BorderStyle =
            BorderStyle.FixedSingle;

        Controls.Add(leftPanel);

        int y = 40;

        Label lblRing = CreateLabel("Ring ID:", y);
        leftPanel.Controls.Add(lblRing);

        txtRingId = CreateTextBox(y);
        leftPanel.Controls.Add(txtRingId);

        y += 70;

        Label lblName = CreateLabel("Name:", y);
        leftPanel.Controls.Add(lblName);

        txtBirdName = CreateTextBox(y);
        leftPanel.Controls.Add(txtBirdName);

        y += 70;

        Label lblYear = CreateLabel("Hatch Year:", y);
        leftPanel.Controls.Add(lblYear);

        txtHatchYear = CreateTextBox(y);
        leftPanel.Controls.Add(txtHatchYear);

        y += 70;

        Label lblType = CreateLabel("Type:", y);
        leftPanel.Controls.Add(lblType);

        cmbBirdType = new ComboBox();

        cmbBirdType.Location =
            new Point(170, y);

        cmbBirdType.Size =
            new Size(200, 35);

        cmbBirdType.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cmbBirdType.Items.AddRange(
        [
            "Parrot",
            "Eagle",
            "Owl",
            "Cockatiel",
            "Finch"
        ]);

        cmbBirdType.SelectedIndex = 0;

        leftPanel.Controls.Add(cmbBirdType);

        y += 70;

        Label lblColor = CreateLabel("Color:", y);
        leftPanel.Controls.Add(lblColor);

        txtColor = CreateTextBox(y);
        leftPanel.Controls.Add(txtColor);

        y += 70;

        Label lblStatus = CreateLabel("Status:", y);
        leftPanel.Controls.Add(lblStatus);

        cmbStatus = new ComboBox();

        cmbStatus.Location =
            new Point(170, y);

        cmbStatus.Size =
            new Size(200, 35);

        cmbStatus.DropDownStyle =
            ComboBoxStyle.DropDownList;

        cmbStatus.Items.AddRange(
        [
            "In Aviary",
            "Sold",
            "Quarantine"
        ]);

        cmbStatus.SelectedIndex = 0;

        leftPanel.Controls.Add(cmbStatus);

        y += 70;

        chkForSale = new CheckBox();

        chkForSale.Text =
            "Available For Sale";

        chkForSale.Location =
            new Point(170, y);

        chkForSale.AutoSize = true;

        chkForSale.Font =
            new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            );

        leftPanel.Controls.Add(chkForSale);

        y += 80;

        btnAddBird =
            CreateButton(
                "Add Bird",
                Color.MediumSeaGreen,
                30,
                y
            );

        btnAddBird.Click +=
            BtnAddBird_Click;

        leftPanel.Controls.Add(btnAddBird);

        btnRemoveBird =
            CreateButton(
                "Remove Bird",
                Color.IndianRed,
                210,
                y
            );

        btnRemoveBird.Click +=
            BtnRemoveBird_Click;

        leftPanel.Controls.Add(btnRemoveBird);

        y += 90;

        txtSearchBird = new TextBox();

        txtSearchBird.Location =
            new Point(30, y);

        txtSearchBird.Size =
            new Size(220, 35);

        leftPanel.Controls.Add(txtSearchBird);

        btnSearchBird =
            CreateButton(
                "Search",
                Color.SteelBlue,
                260,
                y - 2
            );

        btnSearchBird.Size =
            new Size(110, 40);

        btnSearchBird.Click +=
            BtnSearchBird_Click;

        leftPanel.Controls.Add(btnSearchBird);

        dgvBirds = new DataGridView();

        dgvBirds.Location =
            new Point(500, 120);

        dgvBirds.Size =
            new Size(1100, 650);

        dgvBirds.ColumnCount = 7;

        dgvBirds.Columns[0].Name = "Ring ID";
        dgvBirds.Columns[1].Name = "Name";
        dgvBirds.Columns[2].Name = "Hatch Year";
        dgvBirds.Columns[3].Name = "Type";
        dgvBirds.Columns[4].Name = "Color";
        dgvBirds.Columns[5].Name = "Status";
        dgvBirds.Columns[6].Name = "For Sale";

        dgvBirds.Columns[0].Width = 130;
        dgvBirds.Columns[1].Width = 130;
        dgvBirds.Columns[2].Width = 130;
        dgvBirds.Columns[3].Width = 130;
        dgvBirds.Columns[4].Width = 130;
        dgvBirds.Columns[5].Width = 150;
        dgvBirds.Columns[6].Width = 130;

        dgvBirds.BackgroundColor =
            Color.White;

        dgvBirds.BorderStyle =
            BorderStyle.None;

        dgvBirds.RowHeadersVisible = false;

        dgvBirds.AllowUserToAddRows = false;

        dgvBirds.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvBirds.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.None;

        dgvBirds.ColumnHeadersDefaultCellStyle.Font =
            new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            );

        dgvBirds.ColumnHeadersDefaultCellStyle.BackColor =
            Color.LightSteelBlue;

        dgvBirds.EnableHeadersVisualStyles = false;

        Controls.Add(dgvBirds);

        btnSortBirds =
            CreateButton(
                "Sort By Hatch Year",
                Color.Goldenrod,
                550,
                800
            );

        btnSortBirds.Size =
            new Size(230, 55);

        btnSortBirds.Click +=
            BtnSortBirds_Click;

        Controls.Add(btnSortBirds);

        btnGenerateBirds =
            CreateButton(
                "Generate 10,000",
                Color.DeepSkyBlue,
                850,
                800
            );

        btnGenerateBirds.Size =
            new Size(250, 55);

        btnGenerateBirds.Click +=
            BtnGenerateBirds_Click;

        Controls.Add(btnGenerateBirds);

        lblBirdCount = new Label();

        lblBirdCount.Location =
            new Point(1200, 780);

        lblBirdCount.Font =
            new Font(
                "Segoe UI",
                14,
                FontStyle.Bold
            );

        lblBirdCount.AutoSize = true;

        Controls.Add(lblBirdCount);

        lblAverageAge = new Label();

        lblAverageAge.Location =
            new Point(1200, 820);

        lblAverageAge.Font =
            new Font(
                "Segoe UI",
                14,
                FontStyle.Bold
            );

        lblAverageAge.AutoSize = true;

        Controls.Add(lblAverageAge);

        lblBirdsForSale = new Label();

        lblBirdsForSale.Location =
            new Point(1200, 860);

        lblBirdsForSale.Font =
            new Font(
                "Segoe UI",
                14,
                FontStyle.Bold
            );

        lblBirdsForSale.AutoSize = true;

        Controls.Add(lblBirdsForSale);

        RefreshBirdList();
    }

    private Label CreateLabel(string text, int y)
    {
        return new Label
        {
            Text = text,
            Location = new Point(30, y),
            AutoSize = true,
            Font = new Font(
                "Segoe UI",
                12,
                FontStyle.Bold
            )
        };
    }

    private TextBox CreateTextBox(int y)
    {
        return new TextBox
        {
            Location = new Point(170, y),
            Size = new Size(200, 35)
        };
    }

    private Button CreateButton(
        string text,
        Color color,
        int x,
        int y
    )
    {
        return new Button
        {
            Text = text,
            BackColor = color,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Location = new Point(x, y),
            Size = new Size(150, 50),
            Font = new Font(
                "Segoe UI",
                11,
                FontStyle.Bold
            )
        };
    }

    private void BtnGenerateBirds_Click(
        object? sender,
        EventArgs e
    )
    {
        var oldBirds =
            databaseService.GetAllBirds();

        foreach (var oldBird in oldBirds)
        {
            databaseService.DeleteBird(
                oldBird.RingId
            );
        }

        Random random = new Random();

        string[] names =
        {
            "Rio",
            "Sky",
            "Kiwi",
            "Luna",
            "Sunny"
        };

        string[] types =
        {
            "Parrot",
            "Eagle",
            "Owl",
            "Cockatiel",
            "Finch"
        };

        string[] colors =
        {
            "Green",
            "Blue",
            "Yellow",
            "White",
            "Red"
        };

        string[] statuses =
        {
            "In Aviary",
            "Sold",
            "Quarantine"
        };

        for (int i = 0; i < 10000; i++)
        {
            Bird bird =
                new Bird
                (
                    "AUTO" + i,

                    names[random.Next(names.Length)],

                    random.Next(2000, 2026),

                    types[random.Next(types.Length)],

                    colors[random.Next(colors.Length)],

                    statuses[random.Next(statuses.Length)],

                    random.Next(2) == 1
                );

            databaseService.AddBird(bird);
        }

        RefreshBirdList();

        MessageBox.Show(
            "Exactly 10,000 birds generated successfully!"
        );
    }

    private void BtnAddBird_Click(
        object? sender,
        EventArgs e
    )
    {
        if (string.IsNullOrWhiteSpace(txtBirdName.Text))
{
    MessageBox.Show(
        "Bird Name field is required!",
        "Validation Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );

    txtBirdName.Focus();

    return;
}

if (
    !txtBirdName.Text
    .All(c => char.IsLetter(c) || c == ' ')
)
{
    MessageBox.Show(
        "Bird Name must contain letters only!",
        "Validation Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );

    txtBirdName.Focus();

    return;
}

if (txtBirdName.Text.Trim().Length < 2)
{
    MessageBox.Show(
        "Bird Name is too short!",
        "Validation Error",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
    );

    txtBirdName.Focus();

    return;
}

        if (string.IsNullOrWhiteSpace(txtBirdName.Text))
        {
            MessageBox.Show(
                "Bird Name field is required!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtBirdName.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(txtHatchYear.Text))
        {
            MessageBox.Show(
                "Hatch Year field is required!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtHatchYear.Focus();

            return;
        }

        if (!int.TryParse(txtHatchYear.Text, out int hatchYear))
        {
            MessageBox.Show(
                "Hatch Year must contain numbers only!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtHatchYear.Focus();

            return;
        }

        if (
            hatchYear < 1900 ||
            hatchYear > DateTime.Now.Year
        )
        {
            MessageBox.Show(
                $"Hatch Year must be between 1900 and {DateTime.Now.Year}",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtHatchYear.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(txtColor.Text))
        {
            MessageBox.Show(
                "Color field is required!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            txtColor.Focus();

            return;
        }

        try
        {
            Bird bird =
                new Bird(
                    txtRingId.Text.Trim(),

                    txtBirdName.Text.Trim(),

                    hatchYear,

                    cmbBirdType.SelectedItem!
                    .ToString()!,

                    txtColor.Text.Trim(),

                    cmbStatus.SelectedItem!
                    .ToString()!,

                    chkForSale.Checked
                );

            databaseService.AddBird(bird);

            RefreshBirdList();

            MessageBox.Show(
                "Bird added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtRingId.Clear();
            txtBirdName.Clear();
            txtHatchYear.Clear();
            txtColor.Clear();

            txtRingId.Focus();
        }
        catch
        {
            MessageBox.Show(
                "Ring ID already exists!",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private void BtnRemoveBird_Click(
        object? sender,
        EventArgs e
    )
    {
        if (dgvBirds.SelectedRows.Count == 0)
        {
            MessageBox.Show(
                "Please select a bird first!",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        string ringId =
            dgvBirds.SelectedRows[0]
            .Cells[0]
            .Value!
            .ToString()!;

        databaseService.DeleteBird(ringId);

        RefreshBirdList();

        MessageBox.Show(
            "Bird removed successfully!"
        );
    }

    private void BtnSearchBird_Click(
        object? sender,
        EventArgs e
    )
    {
        if (
            string.IsNullOrWhiteSpace(
                txtSearchBird.Text
            )
        )
        {
            MessageBox.Show(
                "Please enter Ring ID to search!",
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        foreach (DataGridViewRow row in dgvBirds.Rows)
        {
            row.Selected = false;

            string ringId =
                row.Cells[0]
                .Value!
                .ToString()!;

            if (
                ringId.ToLower() ==
                txtSearchBird.Text
                .Trim()
                .ToLower()
            )
            {
                row.Selected = true;

                dgvBirds.FirstDisplayedScrollingRowIndex =
                    row.Index;

                MessageBox.Show(
                    "Bird Found!"
                );

                return;
            }
        }

        MessageBox.Show(
            "Bird Not Found!"
        );
    }

    private void BtnSortBirds_Click(
        object? sender,
        EventArgs e
    )
    {
        var birds =
            databaseService
            .GetAllBirds()
            .OrderByDescending(
                b => b.HatchYear
            )
            .ToList();

        dgvBirds.Rows.Clear();

        foreach (var bird in birds)
        {
            dgvBirds.Rows.Add(
                bird.RingId,
                bird.Name,
                bird.HatchYear,
                bird.Type,
                bird.Color,
                bird.Status,
                bird.IsForSale ? "Yes" : "No"
            );
        }

        MessageBox.Show(
            "Birds sorted successfully!"
        );
    }

    private void RefreshBirdList()
    {
        dgvBirds.Rows.Clear();

        var birds =
            databaseService
            .GetAllBirds();

        foreach (var bird in birds)
        {
            dgvBirds.Rows.Add(
                bird.RingId,
                bird.Name,
                bird.HatchYear,
                bird.Type,
                bird.Color,
                bird.Status,
                bird.IsForSale ? "Yes" : "No"
            );
        }

        lblBirdCount.Text =
            $"Birds: {birds.Count}";

        if (birds.Count > 0)
        {
            double averageAge =
                birds.Average(
                    b => DateTime.Now.Year - b.HatchYear
                );

            lblAverageAge.Text =
                $"Average Age: {averageAge:F1}";
        }
        else
        {
            lblAverageAge.Text =
                "Average Age: 0";
        }

        int forSaleCount =
            birds.Count(
                b => b.IsForSale
            );

        lblBirdsForSale.Text =
            $"For Sale: {forSaleCount}";
    }
}