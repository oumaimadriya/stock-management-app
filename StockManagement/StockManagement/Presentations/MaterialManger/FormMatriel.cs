using App.Gwin.Attributes;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    [App.Gwin.Attributes.Menu(EntityType = typeof(Entities.Material), Order = 10, Title = "AjouterGroupe")]
  //  [Menu(Group ="Societe")]
    public partial class FormAjouterGroupe : Form
    {
        public List<string> ls = new List<string>();
        public FormAjouterGroupe()
        {
            InitializeComponent();
        }
    DAL.ModelContext db = new DAL.ModelContext();
        private void FormAjouterGroupe_Load(object sender, EventArgs e)
        {
          

         //  List<Entities.MaterialCategory> Lm =   db.MaterialCategories.ToList<Entities.MaterialCategory>();
            comboBoxcategorie.DataSource = db.MaterialCategories.ToList<Entities.MaterialCategory>();
            comboBoxcategorie.DisplayMember = "Designation";
            comboBoxcategorie.ValueMember = "id";
            comboBoxdelivry.DataSource = db.Deliveries.ToList<Entities.Delivery>();
            comboBoxdelivry.DisplayMember = "Market";
            comboBoxdelivry.ValueMember = "id";


        
       

        }

        private void comboBoxcategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxstate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void button_Ajoutr_Click(object sender, EventArgs e)
        {

            
                    listBox1.Items.Add(serieNumberTextBox.Text);
                    ls.Add(serieNumberTextBox.Text);
                    serieNumberTextBox.Text = "";

             
                
                
            

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            for (int i=0; i < ls.Count; i++)
            {
                Entities.Material m = new Entities.Material();
                m.SerieNumber = ls[i].ToString();

                m.Designation= new LocalizedString();
                // MessageBox.Show(ls[i].ToString());
                m.Designation.Current = designationTextBox.Text ;
                m.UpdateServiceDate = updateServiceDateDateTimePicker.Value;
                m.Observation = new LocalizedString();
                m.Observation.Current = observationTextBox.Text;
                m.dimension = float.Parse(dimensionTextBox.Text);
                m.INN_Number = iNN_NumberTextBox.Text;
                m.MaterialCategory = db.MaterialCategories.Find(int.Parse(comboBoxcategorie.SelectedValue.ToString()));
                m.Delivery = db.Deliveries.Find(int.Parse(comboBoxdelivry.SelectedValue.ToString()));
                m.InventoryNumber = new LocalizedString();
                m.InventoryNumber.Current = textBoxInventorynumber.Text;
                m.Mark = new LocalizedString();
                m.Mark.Current = textBoxMark.Text;
                m.Model = new LocalizedString();
                m.Model.Current = textBoxModel.Text;
                    db.Materials.Add(m);
                db.SaveChanges();

            }
            MessageBox.Show("l operation a effectuer");

        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
            ls.Remove(serieNumberTextBox.Text);
        }

        private void iNN_NumberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
