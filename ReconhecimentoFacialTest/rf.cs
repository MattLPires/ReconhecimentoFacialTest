using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ReconhecimentoFacialTest
{
    public partial class Form1 : Form
    {

        //Declarando variáveis

        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetectada;
        Image<Bgr, Byte> Frame;
        Capture cam;
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> Users = new List<string>();
        int Count, NumLabels, t;
        string nome, nomes = null;

        private void btnDetec_Click(object sender, EventArgs e)
        {
            cam = new Capture();
            cam.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }

        private void btnCad_Click(object sender, EventArgs e)
        {
            Count = Count + 1;
            grayFace = cam.QueryGrayFrame().Resize(600, 500, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(faceDetectada, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(90, 90));
            foreach (MCvAvgComp f in DetectedFaces[0])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray, Byte>();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(txtCad.Text);
            File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingImages.ToArray().Length.ToString() + ",");
            for (int i = 1; i<trainingImages.ToArray().Length + 1; i++)
            {
                trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", labels.ToArray()[i - 1] + ",");

            }
            MessageBox.Show(txtCad.Text + " Cadastrado com sucesso!");
        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            Users.Add("");
            Frame = cam.QueryFrame().Resize(600, 500, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayFace = Frame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetectadasNow = grayFace.DetectHaarCascade(faceDetectada, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(90, 90));
            foreach (MCvAvgComp f in facesDetectadasNow[0])
            {
                result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100,100,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Frame.Draw(f.rect, new Bgr(Color.Green), 3);
                if (trainingImages.ToArray().Length !=0)
                {
                    MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
                    EigenObjectRecognizer reconhecer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                    nome = reconhecer.Recognize(result);
                    Frame.Draw(nome, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                }

                Users.Add("");
            }
            camBox.Image = Frame;
            nomes = "";
            Users.Clear();
        }

        public Form1()
        {
            InitializeComponent();

            //Declarando o HaarCascade para a detecção
            faceDetectada = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string LabelsInf = File.ReadAllText(Application.StartupPath + "/Faces/Faces.txt");
                string[] Labels = LabelsInf.Split(',');

                //O primeiro campo vai armazenar o número de faces salvas

                NumLabels = Convert.ToInt16(Labels[0]);

                Count = NumLabels;
                string FacesLoad;
                for (int i=1; i<NumLabels + 1; i++)
                {
                    FacesLoad = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + $"/Faces/{FacesLoad}"));
                    labels.Add(Labels[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nenhum dado encontrado");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
