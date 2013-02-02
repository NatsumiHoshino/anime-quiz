﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Anime_Quiz.DataModel;
using Anime_Quiz.Properties;
using System.Collections;
using System.Reflection;
//using System.Globalization;
using System.Data.SQLite;
using Microsoft.VisualBasic;

namespace Anime_Quiz
{
    public partial class GameSetEditor : Form
    {
        //new gameset
        SQLiteDatabase sqlDB = new SQLiteDatabase();

        QuestionSet questionSet;
        Question blankQuestion = new Question();
        Types selectedType;

        int numQuest;   //to deprecate
        FlowLayoutPanel gamePanel = new FlowLayoutPanel();  //to deprecate?

        public GameSetEditor()
        {
            InitializeComponent();
            questionSet = new QuestionSet();
            loadQuestionSets();
            //TODO: load info from database
            /*
            //Load the last game if there is one in memory
            if (Settings.Default.currentSet != null)
                loadFromDatabaseBehavior(0);    //not implemented
            //if (Settings.Default.currentFile != String.Empty)
            //    loadBehavior();
            */
        }

        private void reinitializeGameBoard()
        {
            //Change the saveState to false
            Settings.Default.saveState = false;
            //cancelBtn.Text = CultureInfo.CurrentUICulture.Name.Equals("ja-JP")?"キャンセル":"Cancel";
            cancelBtn.Text = "Cancel";

            //Create the number of specified question boxes for the selected game type.          
            gamePanel.Location = new Point(12, 56);
            gamePanel.AutoScroll = true;
            gamePanel.Width = ClientRectangle.Width - 20;
            gamePanel.Height = ClientRectangle.Height - 64;
            Controls.Add(gamePanel);
            switch (selectedType)
            {
                case Types.Question:
                    for (int i = 0; i < numQuest; i++)
                        addQuestion(blankQuestion);
                    break;
                case Types.Music:
                    for (int i = 0; i < numQuest; i++)
                        addMusic(blankQuestion);
                    break;
                case Types.Screenshot:
                    for (int i = 0; i < numQuest; i++)
                        addScreenshot(blankQuestion);
                    break;
                default:
                    /*if (CultureInfo.CurrentUICulture.Name.Equals("ja-JP"))
                        MessageBox.Show("エラー：ゲームタイプを選んでいなかった \nβακα…_〆(゜▽゜*)(((;゜Д゜))",
                        "エラー", MessageBoxButtons.OK);*/
                    //else 
                    MessageBox.Show("FAIL: You have not selected any question type herp derp.", 
                        "Something went wrong", MessageBoxButtons.OK);
                    break;
            }
        }
        #region Database Load
        /// <summary>
        ///     Loads the QuestionSets from the database and display them in a ComboBox
        /// </summary>
        private void loadQuestionSets()
        {
            String query = "select * from QuestionSets";
            DataTable queryData = sqlDB.getDataTable(query);
            ComboBox questionSetList = new ComboBox();
            questionSetList.Location = new Point(12,12);
            questionSetList.Size = new Size(163, 21);
            questionSetList.Text = "Select a game to load";
            questionSetList.TabIndex = 1;
            questionSetList.SelectedIndexChanged += questionSetList_SelectedIndexChanged;

            foreach (DataRow row in queryData.Rows)
            {
                questionSetList.Items.Add(row["name"]);
            }
            Controls.Add(questionSetList);
        }
        private void loadQuestions()
        {
            int questionSetID = sqlDB.getQuestionSetID(questionSet.name);
            String query = String.Format("select * from Questions where questionSet = '{0}'", questionSetID);
            DataTable queryData = sqlDB.getDataTable(query);
            DataGridView questionGridView = new DataGridView();
            questionGridView.Location = new Point(12, 40);
            questionGridView.DataSource = queryData;
            Controls.Add(questionGridView);
        }
        
        #endregion

        #region Panel Items
        private FlowLayoutPanel addPanel()
        {
            FlowLayoutPanel questionPanel = new FlowLayoutPanel();
            questionPanel.Width = 200;
            questionPanel.Height = 210;
            gamePanel.Controls.Add(questionPanel);

            return questionPanel;
        }

        private void addAnswerLabel(FlowLayoutPanel panel, Question question)
        {
            //Answer text box
            Label answerLabel = new Label();
            //answerLabel.Text = CultureInfo.CurrentUICulture.Name.Equals("ja-JP")?"答え:":"Answer:";
            answerLabel.Text = "Answer";
            answerLabel.Margin = new Padding(20, 5, 0, 0);
            panel.Controls.Add(answerLabel);
            TextBox answerTextBox = new TextBox();
            answerTextBox.Multiline = true;
            answerTextBox.AcceptsReturn = true;
            answerTextBox.Text = question.answer;
            answerTextBox.Width = 200;
            answerTextBox.Margin = new Padding(20, 0, 20, 0);
            panel.Controls.Add(answerTextBox);
        }
        private void addPointsLabel(FlowLayoutPanel panel, Question question)
        {
            //Number of points
            Label pointLabel = new Label();
            //pointLabel.Text = CultureInfo.CurrentUICulture.Name.Equals("ja-JP")?"ポイント: ":"Points: ";
            pointLabel.Text = "Points: ";
            pointLabel.Width = 50;
            pointLabel.Margin = new Padding(20, 0, 0, 0);
            panel.Controls.Add(pointLabel);
            TextBox pointTextBox = new TextBox();
            pointTextBox.Multiline = false;
            pointTextBox.Text = question.points.ToString();
            pointTextBox.Width = 25;
            pointTextBox.Margin = new Padding(0, 0, 0, 0);
            pointTextBox.KeyPress += num_KeyPress;
            panel.Controls.Add(pointTextBox);
        }
        private void addAnsweredLabel(FlowLayoutPanel panel, Question question)
        {
            //Question answered or not
            CheckBox answeredCheckBox = new CheckBox();
            answeredCheckBox.Text = "Answered";
            answeredCheckBox.Margin = new Padding(20, 0, 0, 0);
            answeredCheckBox.Checked = question.answered;
            panel.Controls.Add(answeredCheckBox);
        }
        #endregion

        #region Questions
        private void addQuestion(Question question)
        {
            FlowLayoutPanel questionPanel = addPanel();

            //Question text box
            Label questionLabel = new Label();
            questionLabel.Text = selectedType.ToString();
            questionLabel.Margin = new Padding(20, 20, 0, 0);
            questionPanel.Controls.Add(questionLabel);
            TextBox questionTextBox = new TextBox();
            questionTextBox.Multiline = true;
            questionTextBox.AcceptsReturn = true;
            questionTextBox.Text = question.question == null? "": System.Text.Encoding.UTF8.GetString(question.question);
            questionTextBox.Width = 200;
            questionTextBox.Height = 40;
            questionTextBox.Margin = new Padding(20, 0, 20, 0);
            questionPanel.Controls.Add(questionTextBox);

            addAnswerLabel(questionPanel, question);
            addPointsLabel(questionPanel, question);
            addAnsweredLabel(questionPanel, question);
        }
        private void addMusic(Question question)
        {
            FlowLayoutPanel soundPanel = addPanel();

            //Music box
            Button soundPicker = new Button();
            soundPicker.Text = selectedType.ToString();
            soundPicker.Margin = new Padding(20, 20, 0, 0);
            soundPicker.Width = 75;
            soundPicker.Height = 23;
            soundPicker.Click += new EventHandler(soundPicker_Click);
            soundPanel.Controls.Add(soundPicker);
            Label soundPath = new Label();
            soundPath.Margin = new Padding(20, 0, 20, 0);
            soundPath.Text = question.question.ToString();  //temporary
            soundPath.Width = 200;
            soundPath.Height = 50;
            soundPanel.Controls.Add(soundPath);

            addAnswerLabel(soundPanel, question);
            addPointsLabel(soundPanel, question);
            addAnsweredLabel(soundPanel, question);
        }
        private void addScreenshot(Question question)
        {
            FlowLayoutPanel screenshotPanel = addPanel();

            //Screenshot box
            Button imageChooser = new Button();
            imageChooser.Text = selectedType.ToString();
            imageChooser.Margin = new Padding(20, 20, 0, 0);
            imageChooser.Width = 75;
            imageChooser.Height = 23;
            imageChooser.Click += new EventHandler(imageChooser_Click);
            screenshotPanel.Controls.Add(imageChooser);
            Label imagePath = new Label();
            imagePath.Margin = new Padding(20, 0, 20, 0);
            imagePath.Text = question.question.ToString();
            imagePath.Width = 200;
            imagePath.Height = 70;

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Stream defaultImageStream = currentAssembly.GetManifestResourceStream("Anime_Quiz.Data.maedax.png");
            imagePath.Image = Image.FromStream(defaultImageStream);
            screenshotPanel.Controls.Add(imagePath);

            addAnswerLabel(screenshotPanel, question);
            addPointsLabel(screenshotPanel, question);
            addAnsweredLabel(screenshotPanel, question);
        }
        #endregion

        private bool storeData()
        {
            if (questionSet == null)
                questionSet = new QuestionSet();
            
            //For each questionPanel in gamePanel, get each Question and save it.
            for (int i = 0; i < gamePanel.Controls.Count; i++)
            {
                //Check if there is an empty question and skips it
                if (gamePanel.Controls[i].Controls[1].Text == string.Empty &&
                    gamePanel.Controls[i].Controls[3].Text == string.Empty &&
                    gamePanel.Controls[i].Controls[5].Text == string.Empty) { /*do nothing*/}
                //Check if there is an empty field and return an error.
                else if (gamePanel.Controls[i].Controls[1].Text == string.Empty ||
                    gamePanel.Controls[i].Controls[3].Text == string.Empty ||
                    gamePanel.Controls[i].Controls[5].Text == string.Empty)
                {
                    //if (CultureInfo.CurrentUICulture.Name.Equals("ja-JP"))
                    //    MessageBox.Show("エラー：空のフィールドが有ります。全ての質問を確認してください", "エラー", MessageBoxButtons.OK);
                    //else 
                    MessageBox.Show("FAIL: One of the fields is empty. Please check all the questions and retry", 
                        "Empty text error", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    //string question = (string)gamePanel.Controls[i].Controls[1].Text;
                    byte[] question = GetBytes(gamePanel.Controls[i].Controls[1].Text);
                    string answer = (string)gamePanel.Controls[i].Controls[3].Text;
                    //string type = (string)gamePanel.Controls[i].Controls[0].Text;
                    int point = Convert.ToInt32(gamePanel.Controls[i].Controls[5].Text);
                    bool answered = ((CheckBox)gamePanel.Controls[i].Controls[6]).Checked;
                    questionSet.Add(new Question(question, answer, point, answered));
                }
            }
            return true;
        }

        /// <summary>
        ///     Save each Question in the QuestionSet to the database.
        /// </summary>
        /// <param name="questionSetID">The QuestionSet to which the current questions belong.</param>
        private void saveToDatabase(int questionSetID)
        {
            if (storeData())
            {
                foreach (Question question in questionSet)
                {
                    Dictionary<String, String> data = new Dictionary<string, string>();
                    data.Add("question", GetString(question.question));
                    data.Add("answer", question.answer);
                    data.Add("points", question.points.ToString());
                    data.Add("answered", question.answered.ToString());
                    data.Add("questionSet", questionSetID.ToString());
                    try
                    {
                        if (!sqlDB.Insert("Questions", data))
                            throw new Exception("There was an error inserting a question");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        #region Behaviors

        private void saveAsBehavior()
        {
            string questionSetName = Interaction.InputBox("Choose a name for this Question Set: ", "Game Editor", "sample");
            questionSet = new QuestionSet();
            questionSet.name = questionSetName;
            questionSet.type = selectedType;
            Dictionary<string,string> data = new Dictionary<string,string>();
            data.Add("name", questionSetName);
            data.Add("type", ((int)questionSet.type).ToString());
            sqlDB.Insert("QuestionSets", data);

            int questionSetId = sqlDB.getQuestionSetID(questionSetName);
            saveToDatabase(questionSetId);
            /*if (gameSave.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.currentFile = gameSave.FileName;
                //saveData(Settings.Default.currentFile);
            }*/
        }
        //If there are no currentFile, prompt for SaveAs
        private void saveBehavior()
        {
            saveAsBehavior();
            if (Settings.Default.currentSet == null)
                saveAsBehavior();
            else
            {
                int questionSetId = sqlDB.getQuestionSetID(Settings.Default.currentSet.name);
                saveToDatabase(questionSetId);
            }
            /*
            if (Settings.Default.currentFile == String.Empty) saveAsBehavior();
            else saveData(Settings.Default.currentFile);
            */
            //updateRecentFiles();
        }
        private void loadFromDatabaseBehavior(int questionSetID)
        {
            clearPanel();

            DataTable questionTable;
            DataTable questionSetTable;
            String query = String.Format("select QUESTION, ANSWER, POINTS, ANSWERED from QUESTIONS where ID = {0}", questionSetID);
            questionTable = sqlDB.getDataTable(query);
            String tableQuery = String.Format("select TYPE from QUESTIONSETS where ID = {0}", questionSetID);
            questionSetTable = sqlDB.getDataTable(tableQuery);
            //Change the saveState to false
            Settings.Default.saveState = false;
            cancelBtn.Text = "Close";

            //Create the number of specified question boxes for the selected game type.          
            gamePanel.Location = new Point(12, 56);
            gamePanel.AutoScroll = true;
            gamePanel.Width = ClientRectangle.Width - 20;
            gamePanel.Height = ClientRectangle.Height - 64;
            Controls.Add(gamePanel);
            //Get the type
            //selectedType = questionSetTable.Rows["TYPE"].ToString();
            //TODO: incomplete!!
        }
        
        void clearPanel()
        {
            while (gamePanel.Controls.Count > 0) gamePanel.Controls.Clear();
        }

        private bool isSafeOverwrite(string message)
        {
            if (!Settings.Default.saveState)
            {
                DialogResult confirm = new DialogResult();
                //confirm = MessageBox.Show(message, CultureInfo.CurrentUICulture.Name.Equals("ja-JP")?"編集中のゲーム":"Unsaved changes", MessageBoxButtons.YesNoCancel);
                confirm = MessageBox.Show(message, "Unsaved changes", MessageBoxButtons.YesNoCancel);
                if (confirm == DialogResult.Cancel) return false;
                else if (confirm == DialogResult.Yes) saveBehavior();
            }
            return true;
        }
        private bool isSafeOverwrite(string message, MessageBoxButtons buttons)
        {
            if (!Settings.Default.saveState)
            {
                DialogResult confirm = new DialogResult();
                //confirm = MessageBox.Show(message, CultureInfo.CurrentUICulture.Name.Equals("ja-JP") ? "編集中のゲーム" : "Unsaved changes", buttons);
                confirm = MessageBox.Show(message, "Unsaved changes", buttons);
                if (confirm == DialogResult.Cancel) return false;
                else if (confirm == DialogResult.Yes) saveBehavior();
            }
            return true;
        }

        #endregion

        #region EventHandlers

        /// <summary>
        ///     Keeps track of the selected QuestionSet and load the Questions from it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void questionSetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Save the current selection
            ComboBox senderComboBox = sender as ComboBox;
            questionSet.name = senderComboBox.SelectedItem.ToString();
            selectedType = (Types) sqlDB.getQuestionSetID(questionSet.name);
            questionSet.type = selectedType;

            // Load the Questions
            loadQuestions();

            clrBtn.Enabled = true;
        }

        void soundPicker_Click(object sender, EventArgs e)
        {
            OpenFileDialog soundFile = new OpenFileDialog();
            //If a default directory has been defined for the soundPicker, set it
            if (Settings.Default.defaultMusicFolder != String.Empty) 
                soundFile.InitialDirectory = Settings.Default.defaultMusicFolder;
            //soundFile.Filter = "MP3 files (*.mp3)|*.mp3|MP4 files (*.mp4)|*.mp4|WAV files (*.wav)|*.wav|WMA files (*.wma)|*.wma";
            soundFile.Filter = "Music Formats|" +
                    "*.mp3;*.ram;*.rm;*.wav;*.wma;*.mid;*.mp4|" +
                    "mp3 (*.mp3)|*.mp3|ram (*.ram)|*.ram|rm (*.rm)|*.rm|" +
                    "wav (*.wav)|*.wav|wma (*.wma)|*.wma|mid (*.mid)|*.mid|" +
                    "mp4 (*.mp4)|*.mp4";
            if (soundFile.ShowDialog() == DialogResult.OK)
            {
                string filename = soundFile.FileName;
                Control soundButton = (Control)sender;
                Label soundPath = (Label)soundButton.Parent.Controls[1];
                soundPath.Text = filename;
            }
        }
        void imageChooser_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageFile = new OpenFileDialog();
            //If a default folder has been defined in Settings, start the dialog in that folder
            if (Settings.Default.defaultScreenshotFolder != String.Empty)
                imageFile.InitialDirectory = Settings.Default.defaultScreenshotFolder;
            imageFile.Filter = "JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|BMP files (*.bmp)|*.bmp";
            if (imageFile.ShowDialog() == DialogResult.OK)
            {
                string filename = imageFile.FileName;
                Control imageButton = (Control)sender;
                Label imagePath = (Label)imageButton.Parent.Controls[1];
                imagePath.Text = filename;
                Image image = Image.FromFile(filename);
                imagePath.Image = image.GetThumbnailImage(200, 40, null, new System.IntPtr());
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear this QuestionSet? This cannot be undone.", "Confirm deletion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sqlDB.ClearTable(questionSet.name);
                clrBtn.Enabled = false;
                loadQuestionSets();
            }
        }
        private void gameType_SelectedIndexChanged(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            String newSetName = newSetTextbox.Text;
            Types newSetType = (Types)(gameType.SelectedIndex + 1);
            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add("name", newSetName);
            data.Add("type", ((int)newSetType).ToString());
            sqlDB.Insert("QuestionSets", data);

            //TODO: load the new set as the current one
        }

        private void uncheckBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            if (isSafeOverwrite("There are unsaved changes. Do you want to save them before closing this form?"))
            {
                Settings.Default.saveState = true;
                this.Close();
            }
        }

        private void GameEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            isSafeOverwrite("Really quit? How about saving unsaved changes?", MessageBoxButtons.YesNo);
            Settings.Default.saveState = true;
        }

        #endregion

        #region helpers
        /// <summary>
        ///     Convert a string to a byte array http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        ///     Convert a byte array to a string http://stackoverflow.com/questions/472906/net-string-to-byte-array-c-sharp
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        #endregion

        

        
    }
}