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

namespace notepadminuminus
{
    public partial class Form1 : Form
    {
        bool hasbeensavedinlaction;
        bool hasbeensaved;
        bool newfile;
        string currentfilepath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                richTextBox1.LoadFile(openFileDialog1.FileName);
                currentfilepath = openFileDialog1.FileName;
                hasbeensavedinlaction = true;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if(!hasbeensavedinlaction)
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                    currentfilepath = saveFileDialog1.FileName;

                }
                hasbeensavedinlaction = true;
            }
            else if(hasbeensavedinlaction)
            {
                richTextBox1.SaveFile(currentfilepath);
                hasbeensaved = true;
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;  
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((!hasbeensaved)||(!hasbeensavedinlaction))
            {
                DialogResult dialogResult = MessageBox.Show("wanna save??", "hasnt been saves", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if(hasbeensavedinlaction)
                        richTextBox1.SaveFile(currentfilepath);
                    else
                    {
                        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            richTextBox1.SaveFile(saveFileDialog1.FileName);
                            currentfilepath = saveFileDialog1.FileName;

                        }
                        
                    }
                    hasbeensavedinlaction = true;
                    hasbeensaved = true;
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
                


            }
            richTextBox1.Text = "";
            richTextBox1.Font = DefaultFont;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);
                currentfilepath = saveFileDialog1.FileName;

            }
            hasbeensavedinlaction = true;
            hasbeensaved = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            hasbeensaved = false;
        }
    }
}
