public static class EmailContentBuilder
{
    public static (string subject, string body) BuildMilestoneEmail(int score)
    {
        string subject = $"Milestone reached - {score} points";

        string body =
            "Milestone achieved!\n\n" +
            $"Current Score: {score}\n" +
            $"Time: {System.DateTime.Now}\n\n" +
            "Keep playing to reach 100 points!";

        return (subject, body);
    }

    public static (string subject, string body) BuildCompletionEmail()
    {
        string subject = "Game completed - 100 points";

        string body =
            "Congratulations!\n\n" +
            "You completed the game with 100 points.\n" +
            $"Completion Time: {System.DateTime.Now}\n\n" +
            "Well done!";

        return (subject, body);
    }
}