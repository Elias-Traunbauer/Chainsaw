import React, { ReactElement, useEffect, useState } from 'react';
import '#/styles/Form.module.scss';
import { FormField } from '#/models/FormField';

export default function Form({ children, errorModel, onSubmit }: FormProps) {

    const [fields, setFields] = useState<FormField[]>([]);

    // go through each child and register it as a form field
    useEffect(() => {
        const newFields = React.Children.map(children, (child) => {
            const { name, label, type, required, options } = (child as ReactElement).props;
            return { name, label, type, required, options } as FormField;
        })!;
        setFields(newFields);
    }, [children]);
    
    return (
        <>
            <form onSubmit={onSubmit}>
                {fields.map((field) => (
                    <div key={field.name}>
                        <label htmlFor={field.name}>{field.label}</label>
                        {field.type === 'select' ? (
                            <select id={field.name} name={field.name} required={field.required}>
                                {field.options.map((option) => (
                                    <option key={option} value={option}>{option}</option>
                                ))}
                            </select>
                        ) : (
                            <input type={field.type} id={field.name} name={field.name} required={field.required} />
                        )}
                        <span className={"form_error"}>{errorModel?.[field.name]}</span>
                    </div>
                ))}
                <button type="submit">Submit</button>
            </form>
        </>
    );
}
    