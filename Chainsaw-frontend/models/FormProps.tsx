interface FormProps {
    children: React.ReactNode;
    // error Model is a dictionary, where the key is the field name and the value is a list of error messages
    errorModel?: { [key: string]: string[] };
    onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}