using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresParkingSimulation
{
    public partial class FormParking : Form
    {
        public FormParking()
        {
            InitializeComponent();
        }

        Parking parking = new Parking();
        int parkingSituation; // 2 indicates that the vehicles in the parking lot are added to the exit queue, 1 indicates that the car park is full, 0 means that the car park is empty.

        private void FormParking_Load(object sender, EventArgs e)
        {
            btnListele.Visible = false;
            btnCikisKuyrukEkle.Visible = false;
            label2.Visible = false;
            checkBoxListele.Visible = false;
            checkBoxSil.Visible = false;
            btnCikisKuyrukListele.Visible = false;
            btnCikisKuyrukCikar.Visible = false;
        }

        private void BtnArabalarıEkle_Click(object sender, EventArgs e)
        {
            btnListele.Visible = true;
            btnCikisKuyrukEkle.Visible = true;

            MessageBox.Show(parking.AddACarToTheParking());

            btnArabalarıEkle.Enabled = false;
            parkingSituation = 1;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            if (parkingSituation == 1)
            {
                MessageBox.Show(parking.CarListing());
            }
            else if (parkingSituation == 2)
            {
                MessageBox.Show("Vehicles in parking lot added to outlet queue.");
            }
            else
            {
                MessageBox.Show("Parking empty.");
            }
        }

        private void BtnCikisKuyrukEkle_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            checkBoxListele.Visible = true;
            checkBoxSil.Visible = true;

            MessageBox.Show(parking.ExitFromTheParking());

            btnCikisKuyrukEkle.Enabled = false;
            parkingSituation = 2;
        }

        private void CheckBoxListele_CheckedChanged(object sender, EventArgs e)
        {
            if (parkingSituation == 2)
            {
                if (checkBoxListele.Checked == true)
                {
                    checkBoxSil.Enabled = false;
                    btnCikisKuyrukListele.Visible = true;
                }
                else
                {
                    checkBoxSil.Enabled = true;
                    btnCikisKuyrukListele.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Parking is empty. Please try again when parking is full.");
            }
        }

        private void CheckBoxSil_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSil.Checked == true)
            {
                checkBoxListele.Enabled = false;
                btnCikisKuyrukCikar.Visible = true;
            }
            else
            {
                checkBoxListele.Enabled = true;
                btnCikisKuyrukCikar.Visible = false;
            }
        }

        private void BtnCikisKuyrukListele_Click(object sender, EventArgs e)
        {
            MessageBox.Show(parking.QueueListingTheCar());
        }

        private void BtnCikisKuyrukCikar_Click(object sender, EventArgs e)
        {
            if (parkingSituation == 0)
            {
                MessageBox.Show("Park is already empty.");
            }
            else
            {
                MessageBox.Show(parking.TakeTheCarOutOfTheQueue());
            }

            parkingSituation = 0;
        }
    }
}
