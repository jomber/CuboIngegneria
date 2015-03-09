<html>

<head>
<meta http-equiv="Content-Language" content="it">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<link rel="stylesheet" href="css/main-master.css" type="text/css" />
<link rel="stylesheet" href="css/effects.css" type="text/css" />
<script src="js/jquery-1.9.1.min.js"></script>
<script src="js/cubo.js"></script>
<script>
    var id = "home";
    $('#' + id).siblings().find(".active").removeClass("active");
    $('#' + id).addClass("active");
    localStorage.setItem("selectedolditem", id);
</script>
<title><%= Request.ServerVariables("HTTP_HOST") %></title>
<meta http-equiv="refresh" content="0; url=home.aspx" />
</head>
<body>
       <div id="wrapperDefault" runat="server">
           <div class="grow" id="wrapperLogoDefault">
                <a href="http://www.cuboingegneria.it/home.aspx" title="Cubo Ingegneria">
			    <img alt="Cubo-Ingegneria logo" id="logoDefault" src="images/logoCubo.png" /></a>
           </div>
	
	</div>
</body>
</html>
