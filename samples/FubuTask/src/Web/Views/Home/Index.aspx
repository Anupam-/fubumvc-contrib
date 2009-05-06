﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FubuTask.Views.Home.Index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--
Copyright: Daemon Pty Limited 2006, http://www.daemon.com.au
Community: Mollio http://www.mollio.org $
License: Released Under the "Common Public License 1.0", 
http://www.opensource.org/licenses/cpl.php
License: Released Under the "Creative Commons License", 
http://creativecommons.org/licenses/by/2.5/
License: Released Under the "GNU Creative Commons License", 
http://creativecommons.org/licenses/GPL/2.0/
-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>FubuTask :: Home</title>
<%= this.CSS("~/css/main.css").Media("screen")%>
<%= this.CSS("~/css/print.css").Media("print")%>
<!--[if lte IE 6]>
<%= this.CSS("~/css/ie6_or_less.css").Media("screen")%>
<![endif]-->
<%= this.Script("~/js/common.js") %>
</head>
<body id="type-c">
<div id="wrap">

	<div id="header">
		<div id="site-name">FubuTask</div>
		<div id="search">
			<form action="">
			<label for="searchsite">Search:</label>
			<input id="searchsite" name="searchsite" type="text" />
			<input type="submit" value="Go" class="f-submit" />
			</form>
		</div>
		<ul id="nav">
		<li class="first"><a href="#">Home</a></li>
		<li class="active"><a href="#">Products</a>
			<ul>
			<li class="first"><a href="#">Maecenas</a></li>
			<li class="active"><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li class="last"><a href="#">Mauris at enim</a></li>
			</ul>
		</li>
		<li><a href="#">Client list</a>
			<ul>
			<li class="first"><a href="#">Maecenas</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li class="last"><a href="#">Mauris at enim</a></li>
			</ul>
		</li>
		<li><a href="#">Case Studies &amp; References</a>
			<ul>
			<li class="first"><a href="#">Maecenas</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li class="last"><a href="#">Mauris at enim</a></li>
			</ul>
		</li>
		<li class="last"><a href="#">Locations</a>
			<ul>
			<li class="first"><a href="#">Maecenas</a></li>
			<li><a href="#">Phasellus</a></li>
			<li><a href="#">Mauris sollicitudin</a></li>
			<li class="last"><a href="#">Mauris at enim</a></li>
			</ul>
		</li>
		</ul>
	</div>
	
	<div id="content-wrap">
	
		<div id="utility">

			<ul id="nav-secondary">
			<li class="first"><a href="#">Latinus Wordus</a></li>
			<li><a href="#">Catsnamus Mitenus</a></li>
			<li class="active"><a href="#">Beautus Weatherus</a>
			
				<ul>
				<li class="first"><a href="#">Letsgo Surfingus</a></li>
				<li><a href="#">Nothingo on tivio</a></li>
				<li class="active"><a href="#">Wanta a coffeo</a></li>
				<li class="last"><a href="#">Nothingo on tivio</a></li>
				</ul>
			</li>
			<li><a href="#">Bottomus Navigationus</a></li>
			<li><a href="#">Gee my neckus issore</a></li>
			<li class="last"><a href="#">Last buttus notleastus</a></li>
			</ul>
		</div>
		
		<div id="content">
		
			<div id="breadcrumb">
			<a href="homepage.cfm">Home</a> / <a href="devtodo">Section Name</a> / <strong>Page Name</strong>
			</div>
			
			<h1>Heading 1 Consect etuer adipisci ngon.</h1>
			<h2>Heading 2 Consect etuer adipisci ngon.</h2>
			<h3>Heading 3 Consect etuer adipisci ngon.</h3>
			<h4>Heading 4 Consect etuer adipisci ngon.</h4>
			<h5>Heading 5 Consect etuer adipisci ngon.</h5>
			<h6>Heading 6 Consect etuer adipisci ngon.</h6>

			<hr />
			
			<p>A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, </p>
			
			<hr />
			
			<p class="highlight">A paragraph of text with class="highlight", A paragraph of text with class="highlight", A paragraph of text with class="highlight", A paragraph of text with class="highlight", A paragraph of text with class="highlight", </p>
			
			<hr />
			
			<p class="subdued">A paragraph of text with class="subdued", A paragraph of text with class="subdued", A paragraph of text with class="subdued", A paragraph of text with class="subdued", A paragraph of text with class="subdued", </p>
			
			<hr />
			
			<p class="error">A paragraph of text with class="error", A paragraph of text with class="error", A paragraph of text with class="error", A paragraph of text with class="error", A paragraph of text with class="error", </p>
			
			<hr />
			
			<p class="success">A paragraph of text with class="success", A paragraph of text with class="success", A paragraph of text with class="success", A paragraph of text with class="success", A paragraph of text with class="success", </p>
			
			<hr />
			
			<p class="caption">A paragraph of text with class="caption", A paragraph of text with class="caption", A paragraph of text with class="caption", A paragraph of text with class="caption", A paragraph of text with class="caption", </p>
			
			<hr />
			
			<p><small>A paragraph of text with the text with &lt;small&gt; tags, A paragraph of text with the text with &lt;small&gt; tags, A paragraph of text with the text with &lt;small&gt; tags, A paragraph of text with the text with &lt;small&gt; tags, A paragraph of text with the text with &lt;small&gt; tags, </small></p>
			
			<hr />

			
			<p><strong>A paragraph of text with the text with &lt;strong&gt; tags, A paragraph of text with the text with &lt;strong&gt; tags, A paragraph of text with the text with &lt;strong&gt; tags, A paragraph of text with the text with &lt;strong&gt; tags, A paragraph of text with the text with &lt;strong&gt; tags, </strong></p>
			
			<hr />
			
			<div class="featurebox"><h3>A h3 level heading inside a "featurebox" div</h3><p>A normal paragraph of text within a div with a class="featurebox", A normal paragraph of text within a div with a class="featurebox", A normal paragraph of text within a div with a class="featurebox", A normal paragraph of text within a div with a class="featurebox", A normal paragraph of text within a div with a class="featurebox", A normal paragraph of text within a div with a class="featurebox" <a href="devtodo" class="morelink" title="A h3 level heading inside a featurebox div">More <span>about: A h3 level heading inside a featurebox div</span></a></p></div>
			
			<hr />
			
			<ul>
			<li><a href="devtodo">A list of links</a></li>
			<li><a href="devtodo">A list of links</a></li>
			<li><a href="devtodo">A list of links</a></li>
			</ul>
			
			<hr />
			
			<p>A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, A normal paragraph of text, </p>
			<ul class="related">
			<li><a href="devtodo">A list of related links</a></li>
			<li><a href="devtodo">A list of related links</a></li>
			<li><a href="devtodo">A list of related links</a></li>
			</ul>
			
			<hr />
			
			<ul>
			<li>An unordered list</li>
			<li>An unordered list</li>
			<li>An unordered list</li>
			</ul>
			
			<hr />
			
			<ol>
			<li>An ordered list</li>
			<li>An ordered list</li>
			<li>An ordered list</li>
			</ol>
			
			<hr />
			
			<dl>
			<dt>A definition list - and this is the dt</dt>
			<dd>A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, </dd>
			<dt>A definition list - and this is the dt</dt>
			<dd>A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, A definition list - and this is the dd, </dd>
			</dl>
			
			<hr />
			
			<h4><span class="date">29 July 2005</span> Headline and associate teaser</h4>
			<p>Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Donec pharetra. <a href="devtodo" class="morelink" title="Headline and associate teaser">More <span>about: Headline and associate teaser</span></a></p>
			
			<h4><span class="date">29 July 2005</span> Headline and associate teaser</h4>
			<p>Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Donec pharetra. <a href="devtodo" class="morelink" title="Headline and associate teaser">More <span>about: Headline and associate teaser</span></a></p>
			
			<hr />
			
			<h4><span class="date">29 July 2005</span> Headline and associate teaser and thumbnail</h4>
			<p><span class="thumbnail"><a href="devtodo">
			    <img src="<%= "~/images/thumb_100wide.gif".ToFullUrl() %>" alt="Demo" width="100" height="75" />
			    
			    
			    </a></span>Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Donec pharetra. <a href="devtodo" class="morelink" title="Headline and associate teaser">More <span>about: Headline and associate teaser</span></a></p>
			
			<hr />
			
			<h4><span class="date">29 July 2005</span> Headline and associate teaser and thumbnail</h4>
			<p><span class="thumbnail"><a href="devtodo"><img src="<%= "~/images/thumb_100wide.gif".ToFullUrl()%>" alt="Demo" width="100" height="75" /></a></span>Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Lorem ipsum dolor sit amsum dolor sit amet, consectetet, consectetuer adipiscing elit. Donec pharetra. <a href="devtodo" class="morelink" title="Headline and associate teaser">More <span>about: Headline and associate teaser</span></a></p>
			
			<hr />
			
			<div class="pagination">
			<p><span><strong>Previous</strong></span> <span>1</span> <a href="devtodo">2</a> <a href="devtodo">3</a> <a href="devtodo">4</a> <a href="devtodo">5</a> <a href="devtodo"><strong>Next</strong></a></p>
			<h4>Page 1 of 5</h4>
			</div>
			
			<hr />
			
			<h1>Search Results</h1>
			
			<div id="resultslist-wrap">
				<ol>
				<li>
					<dl>
					<dt><a href="devtodo">Fringilla tortor. Sed ullamcorper imperdiet metus.</a></dt>
					<dd class="desc">Maecenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris at enim. Ut vestibulum erat at tellus.</dd>
					<dd class="filetype">HTML</dd>
					<dd class="date">22 April 2005</dd>
					</dl>
				</li>
				<li>
					<dl>
					<dt><a href="devtodo">Fringilla tortor. Sed ullamcorper imperdiet metus.</a></dt>
					<dd class="desc">Maecenas nec ante vitae turpis intecenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris cenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris cenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris cenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris rdum placerat. Duis in nisi. Mauris at enim. Ut vestibulum erat at tellus.</dd>
					<dd class="filetype">HTML</dd>
					<dd class="date">22 April 2005</dd>
					</dl>
				</li>
				<li>
					<dl>
					<dt><a href="devtodo">Fringilla tortor. Sed ullamcorper imperdiet metus.</a></dt>
					<dd class="desc">Maecenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris at enim. Ut vestibulum erat at tellus.</dd>
					<dd class="filetype">PDF</dd>
					<dd class="date">22 April 2005</dd>
					</dl>
				</li>
				<li>
					<dl>
					<dt><a href="devtodo">Fringilla tortor. Sed ullamcorper imperdiet metus.</a></dt>
					<dd class="desc">Maecenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris cenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris cenas nec ante vitae turpis interdum placerat. Duis in nisi. Mauris at enim. Ut vestibulum erat at tellus.</dd>
					<dd class="filetype">WORD</dd>
					<dd class="date">22 April 2005</dd>
					</dl>
				</li>
				</ol>
			</div>
			
			<div id="footer">
			<p>A note here to go in the footer</p>
			<p><a href="#">Contact Us</a> | <a href="#">Privacy</a> | <a href="#">Links</a></p>
			</div>
			
		</div>
		
		<div id="sidebar">

			<div class="featurebox">
			<h3>Mollio v1.0 released</h3>
			<p><strong>FarCry is more than an enterprise-class application.</strong> FarCry is an "out of the box" open source solution, a fully extensible application framework, and a commercially supported services model. </p>
			</div>
			
			<div class="featurebox">
			<h3>New Features</h3>
			<p>FarCry is more than an enterprise-class application. FarCry is an "out of the box" open source</p>
			<ul>
			<li><strong>Super fast</strong></li>
			<li><strong>Standards compliant</strong></li>
			<li><strong>Works out of the box</strong></li>
			</ul>
			</div>
				
		</div>
		
		<div id="poweredby"><a href="http://farcry.daemon.com.au/"><img src="<%= "~/images/mollio.gif".ToFullUrl()%>" alt="FarCry - Mollio" /></a></div>
		
	</div>
	
</div>
</body>
</html>