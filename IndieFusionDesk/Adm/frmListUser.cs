using IndieFusionDesk.Models;
using IndieFusionDesk.Services;
using System.Windows.Forms;

namespace IndieDesk.Adm
{
    public partial class frmListUser : Form
    {
        public frmListUser()
        {
            InitializeComponent();
        }

        private void frmListUser_Load(object sender, EventArgs e)
        {
            LoadDgv1();
        }

        //Load dgv1
        private async void LoadDgv1()
        {
            try
            {
                var list = await UserServices.GetUser();

                dgv1.AutoGenerateColumns = false;
                dgv1.DataSource = null;
                dgv1.Columns.Clear();
                dgv1.DataSource = list;

                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUser", Name = "IdUser", Visible = false });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", Name = "Nome" });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", Name = "Email" });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DisplayUserType", Name = "Tipo Usuario" });

                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Imagem",
                    HeaderText = "Foto",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgv1.Columns.Add(imgCol);

                // Ajusta propriedades visuais do grid
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv1.DefaultCellStyle.Font = new Font("Arial", 10);
                dgv1.RowHeadersVisible = false;
                dgv1.RowTemplate.Height = 120;

                string basePathAPI = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionAPI\wwwroot\";
                string basePathWeb = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionFinal\wwwroot\images";

                foreach (DataGridViewRow row in dgv1.Rows)
                {
                    if (row.DataBoundItem is User user && !string.IsNullOrEmpty(user.ImagePath))
                    {
                        try
                        {
                            string pathCorrigido = user.ImagePath.TrimStart('\\', '/');
                            string fullPathAPI = Path.Combine(basePathAPI, pathCorrigido);

                            string imageName = pathCorrigido;
                            if (imageName.StartsWith("images", StringComparison.OrdinalIgnoreCase))
                            {
                                imageName = imageName.Substring("images".Length).TrimStart('\\', '/');
                            }
                            string fullPathWeb = Path.Combine(basePathWeb, imageName);

                            if (File.Exists(fullPathAPI))
                            {
                                using (var stream = new FileStream(fullPathAPI, FileMode.Open, FileAccess.Read))
                                {
                                    var image = Image.FromStream(stream);
                                    row.Cells["Imagem"].Value = new Bitmap(image); // Usa uma cópia da imagem
                                }
                            }
                            else if (File.Exists(fullPathWeb))
                            {
                                using (var stream = new FileStream(fullPathWeb, FileMode.Open, FileAccess.Read))
                                {
                                    var image = Image.FromStream(stream);
                                    row.Cells["Imagem"].Value = new Bitmap(image); // Usa uma cópia da imagem
                                }
                            }
                            else
                            {
                                string defaultImage = Path.Combine(basePathAPI, "images", "default.png");
                                if (File.Exists(defaultImage))
                                {
                                    using (var stream = new FileStream(defaultImage, FileMode.Open, FileAccess.Read))
                                    {
                                        var image = Image.FromStream(stream);
                                        row.Cells["Imagem"].Value = new Bitmap(image); // Usa uma cópia da imagem
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao carregar imagem: {ex.Message}");
                            row.Cells["Imagem"].Value = null;
                        }
                    }
                    row.Height = 60;
                }

                dgv1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}");
            }
        }

        private void LoadImages()
        {
            // Caminhos base para as imagens
            string basePathAPI = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionAPI\wwwroot\";
            string basePathWeb = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionFinal\wwwroot\images";

            foreach (DataGridViewRow row in dgv1.Rows)
            {
                if (row.DataBoundItem is User user && !string.IsNullOrEmpty(user.ImagePath))
                {
                    try
                    {
                        string pathCorrigido = user.ImagePath.TrimStart('\\', '/');
                        string fullPathAPI = Path.Combine(basePathAPI, pathCorrigido);

                        // Se o ImagePath iniciar com "images", remove esse prefixo
                        string imageName = pathCorrigido;
                        if (imageName.StartsWith("images", StringComparison.OrdinalIgnoreCase))
                        {
                            imageName = imageName.Substring("images".Length).TrimStart('\\', '/');
                        }
                        string fullPathWeb = Path.Combine(basePathWeb, imageName);

                        if (File.Exists(fullPathAPI))
                        {
                            row.Cells["Imagem"].Value = Image.FromFile(fullPathAPI);
                        }
                        else if (File.Exists(fullPathWeb))
                        {
                            row.Cells["Imagem"].Value = Image.FromFile(fullPathWeb);
                        }
                        else
                        {
                            string defaultImage = Path.Combine(basePathAPI, "images", "default.png");
                            row.Cells["Imagem"].Value = File.Exists(defaultImage)
                                ? Image.FromFile(defaultImage)
                                : null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao carregar imagem: {ex.Message}");
                        row.Cells["Imagem"].Value = null;
                    }
                }
                row.Height = 60;
            }
        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadDgv1();
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            var list = await UserServices.GetFilterUser(txtFilter.Text);
            dgv1.DataSource = list;
            LoadImages();
            txtFilter.Text = string.Empty;
            txtFilter.Focus();

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
