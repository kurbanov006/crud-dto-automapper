public readonly record struct StudentCreateInfo(
    string FirstName,
    string LastName,
    int Age
);

public readonly record struct StudentGetInfo(
    int Id,
    string FirstName,
    string LastName,
    int Age
);

public readonly record struct StudentUpdateInfo(
    int Id,
    string FirstName,
    string LastName,
    int Age
);