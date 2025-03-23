
using IndieFusionDesk.Models;
using IndieFusionDesk.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;


namespace IndieDesk.Adm
{
    public partial class frmManageUser : Form
    {
        public frmManageUser()
        {
            InitializeComponent();
        }

        //LoadForm
        private void frmManageUser_Load(object sender, EventArgs e)
        {
            LoadDgv1();
            txtId.Enabled = false;
            LoadCbox1();
            ClearField();
        }

        private async void LoadCbox1()
        {
            try
            {
                var userServices = new UserServices();
                List<UserType> lista = await userServices.GetUserTypes();

                if (lista != null && lista.Count > 0)
                {
                    cbox1.DataSource = lista;
                    cbox1.DisplayMember = "Description";
                    cbox1.ValueMember = "Id";
                }
                else
                {
                    MessageBox.Show("Nenhum tipo de usuário encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os tipos de usuário: {ex.Message}");
            }
        }

        private async void LoadDgv1()
        {
            try
            {
                var list = await UserServices.GetUser();

                // Configura o DataGridView para não gerar colunas automaticamente
                dgv1.AutoGenerateColumns = false;
                dgv1.DataSource = null;
                dgv1.Columns.Clear();

                // Define a lista de usuários como fonte
                dgv1.DataSource = list;

                // Cria as colunas de texto
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdUser", Name = "IdUser", Visible = false });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", Name = "Nome" });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", Name = "Email" });
                dgv1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DisplayUserType", Name = "Tipo Usuario" });

                // Ajusta propriedades visuais do grid
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv1.DefaultCellStyle.Font = new Font("Arial", 10);
                dgv1.RowHeadersVisible = false;
                dgv1.RowTemplate.Height = 120;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                // Cria a coluna de imagem (mantém a coluna no grid)
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                {
                    Name = "Imagem",
                    HeaderText = "Foto",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgv1.Columns.Add(imgCol);

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
                                    row.Cells["Imagem"].Value = new Bitmap(image);
                                }
                            }
                            else if (File.Exists(fullPathWeb))
                            {
                                using (var stream = new FileStream(fullPathWeb, FileMode.Open, FileAccess.Read))
                                {
                                    var image = Image.FromStream(stream);
                                    row.Cells["Imagem"].Value = new Bitmap(image); 
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
                                        row.Cells["Imagem"].Value = new Bitmap(image); 
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


        private void loadField()
        {
            if (dgv1.SelectedRows.Count > 0)
            {
                User user = (User)dgv1.SelectedRows[0].DataBoundItem;
                txtId.Text = user.IdUser.ToString();
                txtName.Text = user.Name;
                txtNickName.Text = user.NickName;
                txtEmail.Text = user.Email;
                txtPassword.Text = user.Password;
                txtData.Text = user.BirthDate.ToString("dd-MM-yyyy");

                string basePathAPI = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionAPI\wwwroot\";
                string basePathWeb = @"C:\Users\carlos.ebserra\source\repos\Projeto Final\Projeto Final\IndieFusionFinal\wwwroot\images";

                if (!string.IsNullOrEmpty(user.ImagePath))
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
                        pictureBox1.ImageLocation = fullPathAPI;
                    }
                    else if (File.Exists(fullPathWeb))
                    {
                        pictureBox1.ImageLocation = fullPathWeb;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Path.Combine(basePathAPI, "images", "default.png");
                    }
                }
                else
                {
                    pictureBox1.ImageLocation = Path.Combine(basePathAPI, "images", "default.png");
                }
                cbox1.SelectedValue = user.UserTp;
            }
            else
            {
                ClearField();
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //btnFechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //btnFilter
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            var list = await UserServices.GetFilterUser(txtFilter.Text);
            dgv1.DataSource = list;
            LoadImages();
            txtFilter.Text = string.Empty;
            txtFilter.Focus();
            ClearField();
        }

        //btnClear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
            LoadDgv1();
        }

        //clearfield
        private void ClearField()
        {
            txtId.Text = txtName.Text = txtData.Text = txtNickName.Text = txtEmail.Text = txtPassword.Text = cbox1.Text = txtFilter.Text = string.Empty;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
            }
            cbox1.SelectedIndex = -1;
            txtName.Focus();
        }

        //btnRecord
        private async void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtNickName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtData.Text) ||
                    cbox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios.");
                    return;
                }

                // Criação do objeto User com os dados do formulário
                var user = new User
                {
                    Name = txtName.Text,
                    NickName = txtNickName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    BirthDate = DateTime.Parse(txtData.Text),
                    UserTp = (int)cbox1.SelectedValue
                };

                // Variável para indicar se estamos editando ou criando
                bool isEdit = false;

                // Se houver ID, estamos editando; caso contrário, é criação
                if (!string.IsNullOrWhiteSpace(txtId.Text))
                {
                    user.IdUser = int.Parse(txtId.Text);
                    isEdit = true;
                }

                // Em criação, a imagem é obrigatória; na edição pode ser opcional
                string imagePath = null;
                if (pictureBox1.Image != null)
                {
                    imagePath = SaveImage(pictureBox1.Image);
                }
                else if (!isEdit)
                {
                    MessageBox.Show("Por favor, faça o upload da imagem.");
                    return;
                }

                bool result = false;
                if (isEdit)
                {
                    result = await UserServices.PutUser(user, imagePath);
                    if (result)
                    {
                        MessageBox.Show($"Usuário {user.Name.ToUpper()} editado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao editar usuário. Verifique os dados e tente novamente.");
                    }
                }
                else
                {
                    result = await UserServices.PostUser(user, imagePath);
                    if (result)
                    {
                        MessageBox.Show($"Usuário {user.Name.ToUpper()} cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao criar usuário. Verifique os dados e tente novamente.");
                    }
                }

                LoadDgv1();
                ClearField();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar usuário: {ex.Message}");
            }
        }






        private string SaveImage(Image image)
        {
            // Gera um caminho temporário para salvar a imagem (formato JPG)
            string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
            image.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return tempPath;
        }



        //btnDelete
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show($"Deseja realmente excluir esse Registro?", "ATENÇÂO!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                int idUser = Convert.ToInt32(txtId.Text);
                var result = await UserServices.DeleteUser(idUser);
                MessageBox.Show($"Usuário {txtName.Text.ToUpper()} Excluido com sucesso !!");
                LoadDgv1();
            }
            else if (msg == DialogResult.No)
            {
                ClearField();
            }
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Carrega a imagem selecionada no PictureBox para visualização
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que a linha clicada seja válida
            {
                loadField();
            }
        }


    }
}
