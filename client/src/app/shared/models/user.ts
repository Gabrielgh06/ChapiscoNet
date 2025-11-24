export type User = {
    firstName: string;
    lastName: string;
    email: string;
    address: Address
}

export type Address = {
    ZipCode: string;
    Street: string;
    Number: string;
    Complement?: string;
    Neighborhood: string;
    City: string;
    State: string;
}