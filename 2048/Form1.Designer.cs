namespace _2048
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.score_label = new System.Windows.Forms.Label();
			this.value_list = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// score_label
			// 
			this.score_label.AutoSize = true;
			this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.score_label.Location = new System.Drawing.Point(15, 13);
			this.score_label.Name = "score_label";
			this.score_label.Size = new System.Drawing.Size(81, 20);
			this.score_label.TabIndex = 16;
			this.score_label.Text = "Score : 0";
			// 
			// value_list
			// 
			this.value_list.FormattingEnabled = true;
			this.value_list.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.value_list.Location = new System.Drawing.Point(116, 90);
			this.value_list.Name = "value_list";
			this.value_list.Size = new System.Drawing.Size(58, 108);
			this.value_list.TabIndex = 17;
			this.value_list.TabStop = false;
			this.value_list.UseTabStops = false;
			this.value_list.SelectedIndexChanged += new System.EventHandler(this.value_list_SelectedValueChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(289, 308);
			this.Controls.Add(this.value_list);
			this.Controls.Add(this.score_label);
			this.Name = "Form1";
			this.Text = "2048";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label score_label;
		private System.Windows.Forms.ListBox value_list;
	}
}

