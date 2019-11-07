<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Tayan.sys.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Login</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="/sys/assets/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/sys/assets/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="/sys/assets/css/form-elements.css"/>
    <link rel="stylesheet" href="/sys/assets/css/style.css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

    <!-- Favicon and touch icons -->
    <link rel="shortcut icon" href="sys/assets/ico/favicon.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="/sys/assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="/sys/assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="/sys/assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="/sys/assets/ico/apple-touch-icon-57-precomposed.png"/>
    
</head>
<body>
   
        <!-- Top content -->
        <div class="top-content">
        	
            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>Cynthia後台系統 </strong> Login Form</h1>
                            <div class="description">
                            	<p>
	                            	歡迎使用Cynthia後台系統
                            	</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                        	<div class="form-top">
                        		<div class="form-top-left">
                        			<h3>Login</h3>
                            		<p>Enter your username and password to log on:</p>
                        		</div>
                        		<div class="form-top-right">
                        			<i class="fa fa-key"></i>
                        		</div>
                            </div>
                            <div class="form-bottom">
			                    <form role="form" method="post" class="login-form"  id="form1" runat="server">
			                    	<div class="form-group">
			                    		<label class="sr-only" for="username">Username</label>
			                        	<%--<input type="text" name="form-username" placeholder="Username..." class="form-username form-control" id="form-username">--%>
                                        <asp:TextBox ID="username" CssClass="form-username form-control" runat="server"></asp:TextBox>
                                        <%--上下兩種都可以，用input只要加runat="server"就好比較方便--%>
                                    </div>
			                        <div class="form-group">
			                        	<label class="sr-only" for="password">Password</label>
                                        <input type="password" name="pwd" placeholder="Password..." class="form-password form-control" id="password" runat="server"/>
                                        
			                        </div>
                                    <asp:Label ID="alert" runat="server" ForeColor="Red"></asp:Label>
			                        <%--<button type="submit" class="btn" runat="server"></button>--%>
                                    <asp:Button ID="Button1" runat="server" Text="Sign in!" CssClass="btn" OnClick="Button1_Click" />
			                    </form>
		                    </div>
                        </div>
                    </div>
                   
                </div>
            </div>
            
        </div>


        <!-- Javascript -->
        <script src="assets/js/jquery-1.11.1.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.backstretch.min.js"></script>
        <script src="assets/js/scripts.js"></script>
        
        <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->
   
</body>
</html>
