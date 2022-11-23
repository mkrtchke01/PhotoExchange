namespace PhotoExchangeApi.Applications.Responses;

public class GetPostResponse
{
    public int PostId { get; set; }
    public string Photo { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }
    public string UserPhoto { get; set; }
    public int Likes { get; set; }
}