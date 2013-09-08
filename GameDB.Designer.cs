﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 07/09/2013 6:19:14 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace GameContext
{

    [DatabaseAttribute(Name = "main")]
    [ProviderAttribute(typeof(Devart.Data.SQLite.Linq.Provider.SQLiteDataProvider))]
    public partial class GameDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(GameDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);

        partial void InsertQuestions(Questions instance);
        partial void UpdateQuestions(Questions instance);
        partial void DeleteQuestions(Questions instance);
        partial void InsertQuestionSets(QuestionSets instance);
        partial void UpdateQuestionSets(QuestionSets instance);
        partial void DeleteQuestionSets(QuestionSets instance);
        partial void InsertTeams(Teams instance);
        partial void UpdateTeams(Teams instance);
        partial void DeleteTeams(Teams instance);
        partial void InsertTeamMembers(TeamMembers instance);
        partial void UpdateTeamMembers(TeamMembers instance);
        partial void DeleteTeamMembers(TeamMembers instance);

        #endregion

        public GameDataContext() :
        base(GetConnectionString("GameDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public GameDataContext(MappingSource mappingSource) :
        base(GetConnectionString("GameDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        public GameDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public GameDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public GameDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public GameDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Questions> Questions
        {
            get
            {
                return this.GetTable<Questions>();
            }
        }

        public Devart.Data.Linq.Table<QuestionSets> QuestionSets
        {
            get
            {
                return this.GetTable<QuestionSets>();
            }
        }

        public Devart.Data.Linq.Table<Teams> Teams
        {
            get
            {
                return this.GetTable<Teams>();
            }
        }

        public Devart.Data.Linq.Table<TeamMembers> TeamMembers
        {
            get
            {
                return this.GetTable<TeamMembers>();
            }
        }
    }

    /// <summary>
    /// There are no comments for Questions in the schema.
    /// </summary>
    [Table(Name = @"""main"".Questions")]
    public partial class Questions : INotifyPropertyChanging, INotifyPropertyChanged    
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _QuestionId;

        private string _Question;

        private string _Answer;

        private int _Points;

        private bool _Answered;

        private int _QuestionSetId;
        #pragma warning restore 0649

        private EntityRef<QuestionSets> _QuestionSets;
    
        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnQuestionIdChanging(int value);
        partial void OnQuestionIdChanged();
        partial void OnQuestionChanging(string value);
        partial void OnQuestionChanged();
        partial void OnAnswerChanging(string value);
        partial void OnAnswerChanged();
        partial void OnPointsChanging(int value);
        partial void OnPointsChanged();
        partial void OnAnsweredChanging(bool value);
        partial void OnAnsweredChanged();
        partial void OnQuestionSetIdChanging(int value);
        partial void OnQuestionSetIdChanged();
        #endregion

        public Questions()
        {
            this._QuestionSets  = default(EntityRef<QuestionSets>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for QuestionId in the schema.
        /// </summary>
        [Column(Storage = "_QuestionId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "integer NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        public int QuestionId
        {
            get
            {
                return this._QuestionId;
            }
        }

    
        /// <summary>
        /// There are no comments for Question in the schema.
        /// </summary>
        [Column(Storage = "_Question", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "text NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public string Question
        {
            get
            {
                return this._Question;
            }
            set
            {
                if (this._Question != value)
                {
                    this.OnQuestionChanging(value);
                    this.SendPropertyChanging();
                    this._Question = value;
                    this.SendPropertyChanged("Question");
                    this.OnQuestionChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Answer in the schema.
        /// </summary>
        [Column(Storage = "_Answer", AutoSync = AutoSync.OnUpdate, CanBeNull = false, DbType = "text NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public string Answer
        {
            get
            {
                return this._Answer;
            }
            set
            {
                if (this._Answer != value)
                {
                    this.OnAnswerChanging(value);
                    this.SendPropertyChanging();
                    this._Answer = value;
                    this.SendPropertyChanged("Answer");
                    this.OnAnswerChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Points in the schema.
        /// </summary>
        [Column(Storage = "_Points", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public int Points
        {
            get
            {
                return this._Points;
            }
            set
            {
                if (this._Points != value)
                {
                    this.OnPointsChanging(value);
                    this.SendPropertyChanging();
                    this._Points = value;
                    this.SendPropertyChanged("Points");
                    this.OnPointsChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Answered in the schema.
        /// </summary>
        [Column(Storage = "_Answered", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public bool Answered
        {
            get
            {
                return this._Answered;
            }
            set
            {
                if (this._Answered != value)
                {
                    this.OnAnsweredChanging(value);
                    this.SendPropertyChanging();
                    this._Answered = value;
                    this.SendPropertyChanged("Answered");
                    this.OnAnsweredChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for QuestionSetId in the schema.
        /// </summary>
        [Column(Storage = "_QuestionSetId", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int QuestionSetId
        {
            get
            {
                return this._QuestionSetId;
            }
            set
            {
                if (this._QuestionSetId != value)
                {
                    if (this._QuestionSets.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnQuestionSetIdChanging(value);
                    this.SendPropertyChanging();
                    this._QuestionSetId = value;
                    this.SendPropertyChanged("QuestionSetId");
                    this.OnQuestionSetIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for QuestionSets in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="QuestionSets_Questions", Storage="_QuestionSets", ThisKey="QuestionSetId", OtherKey="QuestionSetId", IsForeignKey=true, DeleteOnNull=true)]
        public QuestionSets QuestionSets
        {
            get
            {
                return this._QuestionSets.Entity;
            }
            set
            {
                QuestionSets previousValue = this._QuestionSets.Entity;
                if ((previousValue != value) || (this._QuestionSets.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._QuestionSets.Entity = null;
                        previousValue.Questions.Remove(this);
                    }
                    this._QuestionSets.Entity = value;
                    if (value != null)
                    {
                        this._QuestionSetId = value.QuestionSetId;
                        value.Questions.Add(this);
                    }
                    else
                    {
                        this._QuestionSetId = default(int);
                    }
                    this.SendPropertyChanged("QuestionSets");
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for QuestionSets in the schema.
    /// </summary>
    [Table(Name = @"""main"".QuestionSets")]
    public partial class QuestionSets : INotifyPropertyChanging, INotifyPropertyChanged    
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _QuestionSetId;

        private string _Name;

        private int _Type;
        #pragma warning restore 0649

        private EntitySet<Questions> _Questions;
    
        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnQuestionSetIdChanging(int value);
        partial void OnQuestionSetIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnTypeChanging(int value);
        partial void OnTypeChanged();
        #endregion

        public QuestionSets()
        {
            this._Questions = new EntitySet<Questions>(new Action<Questions>(this.attach_Questions), new Action<Questions>(this.detach_Questions));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for QuestionSetId in the schema.
        /// </summary>
        [Column(Storage = "_QuestionSetId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "integer NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        public int QuestionSetId
        {
            get
            {
                return this._QuestionSetId;
            }
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [Column(Storage = "_Name", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "text NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Type in the schema.
        /// </summary>
        [Column(Storage = "_Type", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                if (this._Type != value)
                {
                    this.OnTypeChanging(value);
                    this.SendPropertyChanging();
                    this._Type = value;
                    this.SendPropertyChanged("Type");
                    this.OnTypeChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Questions in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="QuestionSets_Questions", Storage="_Questions", ThisKey="QuestionSetId", OtherKey="QuestionSetId", DeleteRule="CASCADE")]
        public EntitySet<Questions> Questions
        {
            get
            {
                return this._Questions;
            }
            set
            {
                this._Questions.Assign(value);
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_Questions(Questions entity)
        {
            this.SendPropertyChanging("Questions");
            entity.QuestionSets = this;
        }
    
        private void detach_Questions(Questions entity)
        {
            this.SendPropertyChanging("Questions");
            entity.QuestionSets = null;
        }
    }

    /// <summary>
    /// There are no comments for Teams in the schema.
    /// </summary>
    [Table(Name = @"""main"".Teams")]
    public partial class Teams : INotifyPropertyChanging, INotifyPropertyChanged    
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _TeamId;

        private string _Name;

        private int _Score;
        #pragma warning restore 0649

        private EntitySet<TeamMembers> _TeamMembers;
    
        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnTeamIdChanging(int value);
        partial void OnTeamIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnScoreChanging(int value);
        partial void OnScoreChanged();
        #endregion

        public Teams()
        {
            this._TeamMembers = new EntitySet<TeamMembers>(new Action<TeamMembers>(this.attach_TeamMembers), new Action<TeamMembers>(this.detach_TeamMembers));
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for TeamId in the schema.
        /// </summary>
        [Column(Storage = "_TeamId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "integer NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        public int TeamId
        {
            get
            {
                return this._TeamId;
            }
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [Column(Storage = "_Name", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "text NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Score in the schema.
        /// </summary>
        [Column(Storage = "_Score", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public int Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                if (this._Score != value)
                {
                    this.OnScoreChanging(value);
                    this.SendPropertyChanging();
                    this._Score = value;
                    this.SendPropertyChanged("Score");
                    this.OnScoreChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for TeamMembers in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Teams_TeamMembers", Storage="_TeamMembers", ThisKey="TeamId", OtherKey="TeamId", DeleteRule="CASCADE")]
        public EntitySet<TeamMembers> TeamMembers
        {
            get
            {
                return this._TeamMembers;
            }
            set
            {
                this._TeamMembers.Assign(value);
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void attach_TeamMembers(TeamMembers entity)
        {
            this.SendPropertyChanging("TeamMembers");
            entity.Teams = this;
        }
    
        private void detach_TeamMembers(TeamMembers entity)
        {
            this.SendPropertyChanging("TeamMembers");
            entity.Teams = null;
        }
    }

    /// <summary>
    /// There are no comments for TeamMembers in the schema.
    /// </summary>
    [Table(Name = @"""main"".TeamMembers")]
    public partial class TeamMembers : INotifyPropertyChanging, INotifyPropertyChanged    
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _MemberId;

        private string _MemberName;

        private int _MemberScore;

        private int _TeamId;
        #pragma warning restore 0649

        private EntityRef<Teams> _Teams;
    
        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnMemberIdChanging(int value);
        partial void OnMemberIdChanged();
        partial void OnMemberNameChanging(string value);
        partial void OnMemberNameChanged();
        partial void OnMemberScoreChanging(int value);
        partial void OnMemberScoreChanged();
        partial void OnTeamIdChanging(int value);
        partial void OnTeamIdChanged();
        #endregion

        public TeamMembers()
        {
            this._Teams  = default(EntityRef<Teams>);
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for MemberId in the schema.
        /// </summary>
        [Column(Storage = "_MemberId", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "integer NOT NULL", IsDbGenerated = true, IsPrimaryKey = true)]
        public int MemberId
        {
            get
            {
                return this._MemberId;
            }
        }

    
        /// <summary>
        /// There are no comments for MemberName in the schema.
        /// </summary>
        [Column(Storage = "_MemberName", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "text NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public string MemberName
        {
            get
            {
                return this._MemberName;
            }
            set
            {
                if (this._MemberName != value)
                {
                    this.OnMemberNameChanging(value);
                    this.SendPropertyChanging();
                    this._MemberName = value;
                    this.SendPropertyChanged("MemberName");
                    this.OnMemberNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for MemberScore in the schema.
        /// </summary>
        [Column(Storage = "_MemberScore", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.WhenChanged)]
        public int MemberScore
        {
            get
            {
                return this._MemberScore;
            }
            set
            {
                if (this._MemberScore != value)
                {
                    this.OnMemberScoreChanging(value);
                    this.SendPropertyChanging();
                    this._MemberScore = value;
                    this.SendPropertyChanged("MemberScore");
                    this.OnMemberScoreChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for TeamId in the schema.
        /// </summary>
        [Column(Storage = "_TeamId", AutoSync = AutoSync.Always, CanBeNull = false, DbType = "integer NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int TeamId
        {
            get
            {
                return this._TeamId;
            }
            set
            {
                if (this._TeamId != value)
                {
                    if (this._Teams.HasLoadedOrAssignedValue)
                    {
                        throw new ForeignKeyReferenceAlreadyHasValueException();
                    }

                    this.OnTeamIdChanging(value);
                    this.SendPropertyChanging();
                    this._TeamId = value;
                    this.SendPropertyChanged("TeamId");
                    this.OnTeamIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Teams in the schema.
        /// </summary>
        [Devart.Data.Linq.Mapping.Association(Name="Teams_TeamMembers", Storage="_Teams", ThisKey="TeamId", OtherKey="TeamId", IsForeignKey=true, DeleteOnNull=true)]
        public Teams Teams
        {
            get
            {
                return this._Teams.Entity;
            }
            set
            {
                Teams previousValue = this._Teams.Entity;
                if ((previousValue != value) || (this._Teams.HasLoadedOrAssignedValue == false))
                {
                    this.SendPropertyChanging();
                    if (previousValue != null)
                    {
                        this._Teams.Entity = null;
                        previousValue.TeamMembers.Remove(this);
                    }
                    this._Teams.Entity = value;
                    if (value != null)
                    {
                        this._TeamId = value.TeamId;
                        value.TeamMembers.Add(this);
                    }
                    else
                    {
                        this._TeamId = default(int);
                    }
                    this.SendPropertyChanged("Teams");
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    /// <summary>
    /// There are no comments for Types in the schema.
    /// </summary>
    public enum Types : int
    {
    
        /// <summary>
        /// There are no comments for Types.Question in the schema.
        /// </summary>
        Question,    
        /// <summary>
        /// There are no comments for Types.Music in the schema.
        /// </summary>
        Music,    
        /// <summary>
        /// There are no comments for Types.Screenshot in the schema.
        /// </summary>
        Screenshot
    }
}
