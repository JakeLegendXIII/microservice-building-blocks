namespace ConferenceRegistrationApi.Models;

/*
 * {
    "conference": {
        "id": "someid",
        "name": "Microservice World 2022"
    }
}
 */
//public class ConferenceRegistration
//{
//    public ConferenceInfo Conference { get; set; } = new ConferenceInfo();
//}

//public class ConferenceInfo
//{
//    public string Id { get; set; } = string.Empty;
//    public string Name { get; set; } = string.Empty;
//}

public record ConferenceInfo(string id, string name);
public record ConferenceRegistration
{
    public ConferenceInfo? Conference { get; init; }
}

public record ConferenceConfirmationConferenceResponse(string id, string name);
public record ConferenceConfirmationForResponse(string name, string email);
public record ConferenceConfirmationPaymentResponse(decimal charged, string card);

public record ConferenceConfirmation(ConferenceConfirmationConferenceResponse conference, 
    ConferenceConfirmationForResponse for_info, ConferenceConfirmationPaymentResponse payment);