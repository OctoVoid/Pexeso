namespace Pexeso
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };
        string firstChoise;
        string secondChoise;
        int tries;
        List<PictureBox> pictures;
        PictureBox picA;
        PictureBox picB;

        public Form1()
        {
            InitializeComponent();
            pictures = new List<PictureBox>() { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                                pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                                                pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15,
                                                pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20 };
            RestartGame();
        }

        private void NewGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();  //randomise the list numbers
            numbers = randomList;  // assing the random list to the original one

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }
            tries = 0;
            triesLabel.Text = "Number of tries: " + tries;
            gameOverText.Visible = false;
        }

        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoise == secondChoise)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                triesLabel.Text = "Number of tries: " + tries;
            }

            firstChoise = null;
            secondChoise = null;

            foreach (PictureBox pics in pictures.ToList())
            {
                if (pics.Tag != null)
                {
                    pics.Image = null;
                }
            }

            if (pictures.All(o => o.Tag == null))
            {
                gameOverText.Visible = true;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (firstChoise == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("Images/" + (string)picA.Tag + ".png");
                    firstChoise = (string)picA.Tag;
                }
            }
            else if (secondChoise == null)
            {
                picB = sender as PictureBox;
                if (picB.Tag != null && picB.Image == null)
                {
                    picB.Image = Image.FromFile("Images/" + (string)picB.Tag + ".png");
                    secondChoise = (string)picB.Tag;
                }
            }
            else
            {
                CheckPictures(picA, picB);
            }
        }
    }
}