Photolink => file:///E:/EraaSoft/HTML/Task.HTML


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>HTML Form Example</title>

    <style>
        body {
            font-family: Arial;
            margin: 20px;
        }

        fieldset {
            margin-bottom: 15px;
            padding: 15px;
        }

        legend {
            font-weight: bold;
        }

        label {
            display: inline-block;
            width: 100px;
            margin-bottom: 10px;
        }

        input, textarea, select {
            margin-bottom: 10px;
        }

        .row {
            display: flex;
            gap: 15px;
        }

        .half {
            flex: 1;
        }

        textarea {
            width: 100%;
            height: 80px;
        }
    </style>
</head>

<body>

<h1>HTML Form Example</h1>

<p>
    This is an example of an HTML4 HTML5 form containing various input controls:
</p>

<form>

    <!-- User Information -->
    <fieldset>
        <legend>User Information</legend>

        <label>Username:</label>
        <input type="text"><br>

        <label>Email:</label>
        <input type="email"><br>

        <label>Password:</label>
        <input type="password"><br>
    </fieldset>

    <!-- Contact Information -->
    <div class="row">

        <fieldset class="half">
            <legend>Contact Information</legend>

            <label>Phone:</label>
            <input type="text"><br>

            <label>Email:</label>
            <input type="email"><br>

            <label>Password:</label>
            <input type="password"><br>
        </fieldset>

        <fieldset class="half">
            <legend>Contact Information</legend>

            <label>Phone:</label>
            <input type="text"><br>

            <label>Message:</label><br>
            <textarea></textarea>
        </fieldset>

    </div>

    <!-- Subscription -->
    <fieldset>
        <legend>Subscription</legend>

        <label>Subscribe:</label>
        <input type="checkbox"><br>

        <label>Subscribed:</label>
        <input type="checkbox"><br>
    </fieldset>

    <!-- Preferred Language -->
    <fieldset>
        <legend>Preferred Language</legend>

        <label>Select:</label>
        <select>
            <option>English</option>
            <option>Spanish</option>
            <option>French</option>
            <option>German</option>
        </select>
    </fieldset>

    <!-- Feedback -->
    <fieldset>
        <legend>Feedback</legend>

        <label>Rate:</label>
        <input type="range" min="0" max="10">
    </fieldset>

    <input type="submit" value="Submit">
    <input type="reset" value="Reset">

</form>

</body>
</html>






