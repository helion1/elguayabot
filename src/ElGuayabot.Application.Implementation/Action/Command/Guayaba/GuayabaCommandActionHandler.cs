using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ElGuayabot.Application.Implementation.Common.Response.Text;
using ElGuayabot.Common.Request;
using ElGuayabot.Common.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ElGuayabot.Application.Implementation.Action.Command.Guayaba
{
    public class GuayabaCommandActionHandler : CommonHandler<GuayabaCommandAction, Result>
    {
        public GuayabaCommandActionHandler(ILogger<CommonHandler<GuayabaCommandAction, Result>> logger, IMediator mediatR) : base(logger, mediatR)
        {
        }

        public override async Task<Result> Handle(GuayabaCommandAction request, CancellationToken cancellationToken)
        {
            var responses = new[]
            {
                "Si la piña es conocida como el 'rey' de las frutas, entonces la guayaba se considera la reina",
                "Se cree que es originaria del sur de América Central y México, donde ha sido un cultivo importante durante varios siglos, las guayabas son miembros de la familia de mirto y el eucalipto, que crece en las zonas tropicales en pequeños árboles con corteza lisa, de color cobre",
                "Las guayabas son suaves, dulces y fragantes cuando están maduras",
                "Las guayabas son muy ricas, simplemente cortadas para un bocado o sobre una ensalada",
                "En otras partes del mundo, la guayaba es muy popular como una rica pasta espesa que se hace en queso",
                "El jugo de guayaba fresco es común en Hawái. Y en Fiji, guayabas se utilizan para hacer sabrosas gelatinas",
                "En comparación con la misma cantidad de piña, la guayaba contiene 30 calorías más por porción, pero tres veces más de proteína y más de cuatro veces en fibra",
                "Mientras que las piñas proporcionan 131% del valor diario de vitamina C por cada porción, las guayabas ofrecen un 628%",
                "Las guayabas contienen: vitamina A (21% del valor diario), esencial para mantener las membranas mucosas y la piel saludable",
                "En un estudio, la guayaba mostró un marcado efecto que disminuye la glucosa en la sangre cuando se consumió por adultos en riesgo de diabetes",
                "La guayaba puede ser casi invasiva si se le permite crecer libremente, alcanzando alturas de 30 pies",
                "Los arboles de guayabo pueden producir frutos dos veces por temporada en las zonas donde el clima es adecuado, y pueden vivir alrededor de 40 años",
                "Las hermosas flores comestibles que precipitan el fruto tienen innumerables estambres altos, con pistilos pequeños en sus extremos, que asemejan a las explosiones de fuegos artificiales",
                "*Ensalada de Guayaba Picante*\n*Ingredientes:*\n- 2-4 guayabas medianas\n- ½ cucharadita de comino tostado en polvo\n- Una pizca de Chaat masala\n- Unas ramitas de cilantro u hojas de culantro, finamente picado\n- Jugo de limón al gusto\n- Sal al gusto\n\n*Procedimiento:*\n\n*1.* Pique las guayabas finamente o en trozos pequeños, dependiendo de cómo las prefiera. Asegúrese de que las guayabas que no estén demasiadas maduras o verdes.\n*2.* Transfiera las guayabas cortadas a un recipiente.\n*3.* Agregue el chaat masala, chile rojo en polvo, comino en polvo y la sal.\n*4.* Añada las hojas de cilantro finamente picadas.\n*5.* Exprima el jugo de limón encima y revuelva hasta que todo se mezcle bien.\n*6.* Sirva inmediatamente.",
                
            };
            
            var rnd = new Random();

            var n = rnd.Next(responses.Length);

            var luckyResponse = responses[n];

            return await MediatR.Send(new TextResponse(luckyResponse), cancellationToken);
        }
    }
}