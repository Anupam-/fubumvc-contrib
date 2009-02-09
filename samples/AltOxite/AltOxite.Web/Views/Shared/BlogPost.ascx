﻿<%@ Control Language="C#" AutoEventWireup="true" Inherits="BlogPost" %>
<h2 class="title"><a href="<%= this.UrlTo().PublishedPost(Model) %>"><%= Model.Title %></a></h2>
<div class="posted"><%= Model.LocalPublishedDate %></div>
<div class="content"><%= Model.BodyShort%></div> 
<div class="more"><%-- 
TODO: implement this
if ((int)ViewData["AreaCount"] > 1)
Response.Write(string.Format(Localize("From the {0} {1}."), string.Format("<a href=\"{1}\">{0}</a>", post.Area.Name, Url.Area(post.Area)), post.Area.Type));
--%><%= Resources.Strings.FILED_UNDER %><%= this.RenderPartial().Using<TagLink>().ForEachOf(Model.Tags) %> | <a href=\"<%= this.UrlTo().PublishedPost(Model) %>#comments\"><%= this.GetCommentsText(Model) %></a> <a href="<%= this.UrlTo().PublishedPost(Model) %>" class="arrow">&raquo;</a></div>
