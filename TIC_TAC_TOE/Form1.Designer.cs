namespace TIC_TAC_TOE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Current_symbol = new Label();
            Restert_game = new Button();
            X_victory = new Label();
            O_victory = new Label();
            SuspendLayout();
            // 
            // Current_symbol
            // 
            Current_symbol.AutoSize = true;
            Current_symbol.Location = new Point(606, 9);
            Current_symbol.Name = "Current_symbol";
            Current_symbol.Size = new Size(256, 27);
            Current_symbol.TabIndex = 10;
            Current_symbol.Text = "cURRENT SYMBOL х";
            // 
            // Restert_game
            // 
            Restert_game.Location = new Point(606, 118);
            Restert_game.Name = "Restert_game";
            Restert_game.Size = new Size(212, 86);
            Restert_game.TabIndex = 11;
            Restert_game.Text = "rESTART gAME";
            Restert_game.UseVisualStyleBackColor = true;
            Restert_game.Click += Restert_game_Click;
            // 
            // X_victory
            // 
            X_victory.AutoSize = true;
            X_victory.Location = new Point(606, 274);
            X_victory.Name = "X_victory";
            X_victory.Size = new Size(0, 27);
            X_victory.TabIndex = 12;
            // 
            // O_victory
            // 
            O_victory.AutoSize = true;
            O_victory.Location = new Point(606, 373);
            O_victory.Name = "O_victory";
            O_victory.Size = new Size(0, 27);
            O_victory.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(16F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 600);
            Controls.Add(O_victory);
            Controls.Add(X_victory);
            Controls.Add(Restert_game);
            Controls.Add(Current_symbol);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Current_symbol;
        private Button Restert_game;
        private Label X_victory;
        private Label O_victory;
    }
}
