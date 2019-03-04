namespace _06_FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ConstantData;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split(';');
                var command = tokens[0];

                try
                {
                    if (command == "Team")
                    {
                        var team = new Team(tokens[1]);
                        teams.Add(team);


                    }

                    else if (command == "Add")
                    {
                        var teamName = tokens[1];
                        if (tokens[2] == null || !teams.Any())
                        {
                            throw new ArgumentException(string.Format(Messages.TeamNotExist, teamName));
                        }
                        var playerName = tokens[2];
                        var playerEndurance = double.Parse(tokens[3]);
                        var playerSprint = double.Parse(tokens[4]);
                        var playerDribble = double.Parse(tokens[5]);
                        var playerPassing = double.Parse(tokens[6]);
                        var playerShooting = double.Parse(tokens[7]);
                        var stats = new Stats(playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
                        var player = new Player(playerName, stats);

                        ValidateTeam(teams, teamName);
                        var team = GetTeam(teams, teamName);
                        team.AddPlayer(player);

                    }

                    else if (command == "Remove")
                    {
                        var teamName = tokens[1];
                        var playerName = tokens[2];

                        ValidateTeam(teams, teamName);
                        var team = GetTeam(teams, teamName);
                        team.Remove(playerName);
                    }

                    else if (command == "Rating")
                    {
                        var teamName = tokens[1];

                        ValidateTeam(teams, teamName);
                        var team = GetTeam(teams, teamName);
                        var rating = team.GetRating();
                        Console.WriteLine($"{team.Name} - {Math.Round(rating)}");
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static Team GetTeam(List<Team> teams, string teamName)
        {
            var team = teams.FirstOrDefault(tn => tn.Name == teamName);

            return team;
        }

        public static void ValidateTeam(List<Team> teams, string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(string.Format(Messages.TeamNotExist, teamName));
            }
        }
    }
}
