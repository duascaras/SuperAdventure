using System.Reflection;

namespace SuperAdventure
{
    public partial class WorldMap : Form
    {
        private readonly Assembly _thisAssembly = Assembly.GetExecutingAssembly();

        public WorldMap()
        {
            InitializeComponent();
            SetImage(pic_5_2, "casa");
            SetImage(pic_4_2, "floresta");
            SetImage(pic_3_4, "caverna");
            SetImage(pic_3_2, "centro");
            SetImage(pic_3_3, "bardomoe");
            SetImage(pic_2_2, "cidade");
            SetImage(pic_1_2, "ponte");
            SetImage(pic_0_2, "torre");
            SetImage(pic_3_1, "loja");
            SetImage(pic_4_1, "quintal");
        }

        private void SetImage(PictureBox pictureBox, string imageName)
        {
            using (Stream? resourceStream = _thisAssembly.GetManifestResourceStream(_thisAssembly.GetName().Name + ".Imagens." + imageName + ".jpg"))
            {
                if (resourceStream != null)
                {
                    pictureBox.Image = new Bitmap(resourceStream);
                }
            }
        }
    }
}