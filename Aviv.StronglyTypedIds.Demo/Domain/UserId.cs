namespace Aviv.StronglyTypedIds.Demo.Domain;

[StronglyTypedId(generateJsonConverter: false)]
public readonly partial struct UserIdReadOnly
{
}

[StronglyTypedId(generateJsonConverter: false)]
public partial struct UserId
{
}