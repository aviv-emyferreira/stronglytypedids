namespace Aviv.StronglyTypedIds.Demo.Domain;

public sealed record GetSavedSearchResponse
{
    public required string UserId { get; set; }
}

public sealed record GetSavedSearchResponseWithUserId
{
    public required UserIdReadOnly UserId { get; set; }
}