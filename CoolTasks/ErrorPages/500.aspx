<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="CoolTasks.ErrorPages._500" %>

<!DOCTYPE html>
<html>
<head>
    <title>Cool Tasks - 500</title>
    <meta charset="utf-8" />
</head>
<body>
    <section class="error-handling-body">
        <div class="error-handling-container">
            <div class="error-handling-header">
                <p>Internal Server Error</p>
            </div>

            <p class="error-handling-description">
                Ooooops! Something went really wrong.
            </p>

            <div class="error-handling-links-section">
                <ul class="error-handling-links-section-list">
                    <li><a href="javascript:history.go(-1)">Go back to the previous page</a></li>
                    <li><a href="/">Homepage</a></li>
                </ul>
            </div>
        </div>
    </section>
</body>
</html>
