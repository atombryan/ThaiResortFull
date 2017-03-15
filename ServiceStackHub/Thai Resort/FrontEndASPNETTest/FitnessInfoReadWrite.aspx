<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FitnessInfoReadWrite.aspx.cs" Inherits="FrontEndASPNETTest.FitnessInfoReadWrite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        UserHash
        <asp:TextBox ID="hashBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <strong>Read Plan Info:</strong><br />
        <asp:Button ID="GetFitButton" runat="server" OnClick="Button1_Click" Text="GetFitnessPlan" />
    
    </div>
        <asp:Label ID="fitPlanLabel" runat="server" Text="PlanGoesHere"></asp:Label>
        <br />
        <br />
        <strong>Write Workout info<br />
        <br />
        </strong>Date<strong><asp:Calendar ID="writeDateCal" runat="server"></asp:Calendar>
        <br />
        </strong>Calories Burned<strong>
        <asp:TextBox ID="calBox" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        </strong>Workout Type<strong>
        <asp:TextBox ID="workoutTypeBox" runat="server"></asp:TextBox>
        <br />
        </strong>Reps
        <asp:TextBox ID="RepBox" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="writeWorkoutButton" runat="server" OnClick="writeWorkoutButton_Click" Text="Write Workout" />
        <br />
        <strong>Read Workout Info<br />
        <asp:Calendar ID="readDateCal" runat="server"></asp:Calendar>
        <asp:Label ID="calsLabel" runat="server" Text="Cals Burned Here"></asp:Label>
        <br />
        <asp:Label ID="typesLabel" runat="server" Text="Workout Types Here"></asp:Label>
        <br />
        <asp:Label ID="repsLabel" runat="server" Text="Total Reps Here"></asp:Label>
        <br />
        <asp:Button ID="readWorkoutButton" runat="server" OnClick="readWorkoutButton_Click" Text="Read Workouts" />
        </strong>
    </form>
</body>
</html>
