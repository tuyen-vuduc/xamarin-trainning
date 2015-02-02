﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using JiraMobile.Models;

namespace JiraMobile.Pages
{
	public partial class IssuesFields : ContentPage, JiraMobile.Pages.HttpClientUtils.IProcessBarCallBack
	{
		public IssuesFields ()
		{
			InitializeComponent ();
			BindingContext = FieldModel.FieldModelList;
			this.InitData ();
		}

		async void InitData ()
		{
			var x = await new HttpClientUtils (this).getIssuesById (IssuesDetail.ID);
			IssuesDetail.DataSource.fields = x.fields;

			FieldModel.FieldModelList [0].Value = 
				IssuesDetail.DataSource.fields.project != null ? IssuesDetail.DataSource.fields.project.name : string.Empty;
			FieldModel.FieldModelList [1].Value = 
				IssuesDetail.DataSource.fields.creator != null ? IssuesDetail.DataSource.fields.creator.displayName : string.Empty;
			FieldModel.FieldModelList [2].Value = 
				IssuesDetail.DataSource.fields.assignee != null ? IssuesDetail.DataSource.fields.assignee.displayName : string.Empty;
			FieldModel.FieldModelList [3].Value = 
				IssuesDetail.DataSource.fields.status != null ? IssuesDetail.DataSource.fields.status.name : string.Empty;
			FieldModel.FieldModelList [4].Value = 
				IssuesDetail.DataSource.fields.resolution != null ? IssuesDetail.DataSource.fields.resolution.name : string.Empty;
			FieldModel.FieldModelList [5].Value = 
				IssuesDetail.DataSource.fields.issuetype != null ? IssuesDetail.DataSource.fields.issuetype.name : string.Empty;
			FieldModel.FieldModelList [6].Value = 
				IssuesDetail.DataSource.fields.priority != null ? IssuesDetail.DataSource.fields.priority.name : string.Empty;

			IssuesDetail.DataSource.fields.updated = "Update " + IssuesDetail.DataSource.fields.updated;
			IssuesDetail.DataSource.fields.creator.displayName = "by " + IssuesDetail.DataSource.fields.creator.displayName;
		}

		public void Show()
		{
			processBar.IsVisible = true;
			allFieldsList.IsVisible = false;
		}

		public void Hide()
		{
			processBar.IsVisible = false;
			allFieldsList.IsVisible = true;
		}

		public void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			this.allFieldsList.SelectedItem = null;
		}
	}
}

