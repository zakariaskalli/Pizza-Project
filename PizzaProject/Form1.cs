using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked == true)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMeduim.Checked == true)
                return Convert.ToSingle(rbMeduim.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);

        }

        float GetSelectedCrustPrice()
        {
            if (rbThinkCrust.Checked == true)
                return Convert.ToSingle(rbThinkCrust.Tag);
            else
                return Convert.ToSingle(rbThinCrust.Tag);

        }

        float CalculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkExtraChees.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChees.Tag);

            if (chkMushrooms.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            
            if (chkTomatoes.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);

            if (chkOnion.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            
            if (chkOlives.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkGreenPeppers.Checked)
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);

            return ToppingsTotalPrice;

        }


        float CalculateTotalPrice()
        {
            return ( GetSelectedSizePrice() + CalculateToppingsPrice() + GetSelectedCrustPrice() ) * Convert.ToInt32(numericUpDown1.Value);
        }

        void UpdatePrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateSizeAndPrice()
        {

            UpdatePrice(); 
            
            if (rbSmall.Checked)
            {
                lblTypeSize.Text = "Small";
                return;
            }

            if (rbMeduim.Checked)
            {
                lblTypeSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblTypeSize.Text = "Large";
                return;
            }
        }

        void UpdateCrustAndPrice()
        {
            UpdatePrice();

            if (rbThinCrust.Checked == true)
                lblCrustType.Text = "Thin Crust";
            else
                lblCrustType.Text = "Think Crust";
        }

        void UpdateToppingsAndPrice()
        {
            UpdatePrice();

            string sToppings = "";

            if (chkExtraChees.Checked)
                sToppings += "Extra Chees";

            if (chkMushrooms.Checked)
                sToppings += ", Mushrooms";

            if (chkTomatoes.Checked)
                sToppings += ", Tomatoes";

            if (chkOnion.Checked)
                sToppings += ", Onion";

            if (chkOlives.Checked)
                sToppings += ", Olives";

            if (chkGreenPeppers.Checked)
                sToppings += ", Green Peppers";

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1, sToppings.Length - 1).Trim();
            }

            if (sToppings == "")
            {
                lblToppingsAccesYou.Text = "No Toppings";
                return;
            }
                

            lblToppingsAccesYou.Text = sToppings;

        }

        void UpdateWhereToEat()
        {
            if (rbTakeOut.Checked == true)
                lblWhereToEat.Text = "Take Out";
            else
                lblWhereToEat.Text = "Eat In";
        }

        void DisabledButtons()
        {
            gbSize.Enabled = false;
            gbCurstType.Enabled = false;
            gbToppings.Enabled = false;
            gbWhereToEat.Enabled = false;
            gbTotalPizza.Enabled = false;

            btnOrderPizza.Enabled = false;

           
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbCurstType.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbTotalPizza.Enabled = true;

            numericUpDown1.Value = 1;

            btnOrderPizza.Enabled = true;

            rbMeduim.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;

            chkExtraChees.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;
            chkOlives.Checked = false;
            chkGreenPeppers.Checked = false;

        }

        void UpdateSummary()
        {
            UpdateSizeAndPrice();
            UpdateCrustAndPrice();
            UpdateToppingsAndPrice();
            UpdateWhereToEat();
            UpdatePrice();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSizeAndPrice();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSizeAndPrice();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSizeAndPrice();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustAndPrice();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustAndPrice();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppingsAndPrice();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Paced Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DisabledButtons();
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void rbEatIn_CheckedChanged_1(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }
    }
}
