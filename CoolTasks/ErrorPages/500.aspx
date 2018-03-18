<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="CoolTasks.ErrorPages._500" %>

<!DOCTYPE html>
<html>
<head>
    <title>Rethink</title>
    <meta charset="utf-8" />
</head>
<body>
    <section class="error-handling-body">
        <div class="error-handling-container">
            <div class="error-handling-header">
                <p>Internal Server Error</p>
            </div>

            <p class="error-handling-description">
                We are sorry! The server encountered an internal error and was unable to process your request.
            </p>

            <div class="error-handling-links-section">
                <ul class="error-handling-links-section-list">
                    <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
                    <li>●</li>
                    <li><a href="/">Homepage</a></li>
                </ul>
            </div>
        </div>
    </section>
</body>
</html>
