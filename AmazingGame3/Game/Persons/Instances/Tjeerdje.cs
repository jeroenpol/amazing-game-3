﻿using AmazingGame3.Dialogs;
using AmazingGame3.Infrastructure;
using AmazingGame3.Items.Instances;
using AmazingGame3.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingGame3.Persons.Instances
{
    public class Tjeerdje : PersonBase
    {
        public static bool HasBeenAtToeganspoortjes = false;

        public static int ID = 84124;

        public Tjeerdje()
            : base(ID, name: "Tjeerdje", description: "Je Tjeerdje.")
        {

        }

        public override DialogSegment GetDialog(GameState state, IRoomProvider roomProvider, IRemoteConsole console)
        {
            DialogBuilder builder = new DialogBuilder("Hallo Jasper Maurice Van Noordenburg. Wat kan ik voor je doen?");

            if(HasBeenAtToeganspoortjes == false)
            {
                return builder
                    .AddResponse("Ja ik weet eigenlijk ook niet zo goed waarom ik hier naartoe kwam. De ballen.", "De ballen 2.")
                    .Build();
            }
            else
            {
                return builder
                    .AddResponse("Ik ben echt zo knettertje dom Tjeerd, ik ben alweer mijn pasje vergeten! Kan ik een dagpas krijgen?", "Ja whatever.", continuation =>
                    {
                        Func<GameState, Task> onChosenAsync = async (state) => 
                        {
                            await state.Inventory.AddAsync(new Toegangspasje(), console);
                        };
                        continuation.AddResponse("Bedankt makker maat.", onChosenAsync);
                        continuation.AddResponse("Bedankt lekkertje.", onChosenAsync);
                    })
                    .Build();
            }
        }
    }
}