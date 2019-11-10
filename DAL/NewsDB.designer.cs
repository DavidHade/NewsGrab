﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="NewsDB")]
	public partial class NewsDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNewsEntry(NewsEntry instance);
    partial void UpdateNewsEntry(NewsEntry instance);
    partial void DeleteNewsEntry(NewsEntry instance);
    #endregion
		
		public NewsDBDataContext() : 
				base(global::DAL.Properties.Settings.Default.NewsDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NewsDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NewsDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NewsDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NewsDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<NewsEntry> NewsEntries
		{
			get
			{
				return this.GetTable<NewsEntry>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NewsEntry")]
	public partial class NewsEntry : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<System.DateTime> _TimeAdded;
		
		private string _Headline;
		
		private string _HeadlineUrl;
		
		private string _NewsSource;
		
		private string _Article;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnTimeAddedChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeAddedChanged();
    partial void OnHeadlineChanging(string value);
    partial void OnHeadlineChanged();
    partial void OnHeadlineUrlChanging(string value);
    partial void OnHeadlineUrlChanged();
    partial void OnNewsSourceChanging(string value);
    partial void OnNewsSourceChanged();
    partial void OnArticleChanging(string value);
    partial void OnArticleChanged();
    #endregion
		
		public NewsEntry()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeAdded", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeAdded
		{
			get
			{
				return this._TimeAdded;
			}
			set
			{
				if ((this._TimeAdded != value))
				{
					this.OnTimeAddedChanging(value);
					this.SendPropertyChanging();
					this._TimeAdded = value;
					this.SendPropertyChanged("TimeAdded");
					this.OnTimeAddedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Headline", DbType="NVarChar(MAX)")]
		public string Headline
		{
			get
			{
				return this._Headline;
			}
			set
			{
				if ((this._Headline != value))
				{
					this.OnHeadlineChanging(value);
					this.SendPropertyChanging();
					this._Headline = value;
					this.SendPropertyChanged("Headline");
					this.OnHeadlineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HeadlineUrl", DbType="NVarChar(MAX)")]
		public string HeadlineUrl
		{
			get
			{
				return this._HeadlineUrl;
			}
			set
			{
				if ((this._HeadlineUrl != value))
				{
					this.OnHeadlineUrlChanging(value);
					this.SendPropertyChanging();
					this._HeadlineUrl = value;
					this.SendPropertyChanged("HeadlineUrl");
					this.OnHeadlineUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewsSource", DbType="NVarChar(50)")]
		public string NewsSource
		{
			get
			{
				return this._NewsSource;
			}
			set
			{
				if ((this._NewsSource != value))
				{
					this.OnNewsSourceChanging(value);
					this.SendPropertyChanging();
					this._NewsSource = value;
					this.SendPropertyChanged("NewsSource");
					this.OnNewsSourceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Article", DbType="NVarChar(MAX)")]
		public string Article
		{
			get
			{
				return this._Article;
			}
			set
			{
				if ((this._Article != value))
				{
					this.OnArticleChanging(value);
					this.SendPropertyChanging();
					this._Article = value;
					this.SendPropertyChanged("Article");
					this.OnArticleChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
