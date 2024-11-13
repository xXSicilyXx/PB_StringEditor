using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StringEditor
{
  public class MainForm : Form
  {
    private string selectedFile = "";
    private IContainer components = (IContainer) null;
    private OpenFileDialog openFile;
    private Button encode;
    private Button decode;
    private SaveFileDialog saveFile;
    private Button selectFile;
    private Label label1;
    private TextBox fileText;
    public MainForm()
    {
      this.InitializeComponent();
      this.ChangeState(false);
    }
    private void selectFile_Click(object sender, EventArgs e)
    {
      this.openFile.DefaultExt = ".txt";
      this.openFile.Filter = "Tipo di file (.txt)|*.txt";
      this.openFile.FileName = "";
      if (this.openFile.ShowDialog() != DialogResult.OK) return;
      this.selectedFile = this.openFile.FileName;
      this.fileText.Text = this.selectedFile.Split('\\')[this.selectedFile.Split('\\').Length - 1];
      this.ChangeState(true);
    }
    private void ChangeState(bool State)
    {
      this.decode.Enabled = State;
      this.encode.Enabled = State;
    }
    private void encode_Click(object sender, EventArgs e)
    {
      Encode encode = new Encode(this.selectedFile);
      encode.ReadBytes();
      encode.Decrypt();
      encode.Save();
      string str = this.selectedFile.Split('\\')[this.selectedFile.Split('\\').Length - 1];
      MessageBox.Show("File " + selectedFile + " criptato con successo!", Text);
    }
    private void decode_Click(object sender, EventArgs e)
    {
      Decode decode = new Decode(this.selectedFile);
      decode.ReadBytes();
      decode.Decrypt();
      decode.Save();
      string str = this.selectedFile.Split('\\')[this.selectedFile.Split('\\').Length - 1];
            MessageBox.Show("File " + selectedFile + " decriptato con successo!", Text);
        }
    private void MainForm_Load(object sender, EventArgs e)
    {

    }
    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null) this.components.Dispose();
      base.Dispose(disposing);
    }
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.encode = new System.Windows.Forms.Button();
            this.decode = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.selectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fileText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // encode
            // 
            this.encode.Location = new System.Drawing.Point(11, 76);
            this.encode.Name = "encode";
            this.encode.Size = new System.Drawing.Size(87, 23);
            this.encode.TabIndex = 1;
            this.encode.Text = "Codifica";
            this.encode.UseVisualStyleBackColor = true;
            this.encode.Click += new System.EventHandler(this.encode_Click);
            // 
            // decode
            // 
            this.decode.Location = new System.Drawing.Point(104, 76);
            this.decode.Name = "decode";
            this.decode.Size = new System.Drawing.Size(90, 23);
            this.decode.TabIndex = 2;
            this.decode.Text = "Decodifica";
            this.decode.UseVisualStyleBackColor = true;
            this.decode.Click += new System.EventHandler(this.decode_Click);
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(123, 12);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(71, 27);
            this.selectFile.TabIndex = 3;
            this.selectFile.TabStop = false;
            this.selectFile.Text = "Scegli File";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File";
            // 
            // fileText
            // 
            this.fileText.Enabled = false;
            this.fileText.Location = new System.Drawing.Point(11, 50);
            this.fileText.Name = "fileText";
            this.fileText.Size = new System.Drawing.Size(183, 20);
            this.fileText.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 111);
            this.Controls.Add(this.fileText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.decode);
            this.Controls.Add(this.encode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PB String Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
