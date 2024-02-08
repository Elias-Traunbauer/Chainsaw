/// <reference types="react" />
export interface FormProps {
    children: React.ReactNode;
    errorModel?: {
        [key: string]: string[];
    };
    onSubmit: (event: React.FormEvent<HTMLFormElement>) => void;
}
