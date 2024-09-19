import Modal from "antd/es/modal/Modal";
import { BookRequest } from "../services/books"
import Input from "antd/es/input/Input";
import { useEffect, useState } from "react";

interface Props {
    mode: Mode;
    values: Book;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: BookRequest) => void;
    handleUpdate: (id: string, request: BookRequest) => void;
}

export enum Mode {
    Create,
    Edit
}

export const CreateUpdateBook = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [price, setPrice] = useState<number>(0);

    useEffect(() => {
        setTitle(values.title)
        setDescription(values.description)
        setPrice(values.price)
    }, [values])

    const handleOnOk = async () => {
        const bookRequest = { title, description, price }
        mode == Mode.Create ? handleCreate(bookRequest) : handleUpdate(values.id, bookRequest)
    }

    return (
        <Modal title={mode === Mode.Create ? "Create Book" : "Edit Book"}
            open={isModalOpen}
            cancelText="Cansel"
            onOk={handleOnOk}
            onCancel={handleCancel}        >
            <div className="book__modal">
                <Input value={title} onChange={(e) => setTitle(e.target.value)} placeholder="Title"></Input>
                <Input value={description} onChange={(e) => setDescription(e.target.value)} placeholder="Description"></Input>
                <Input value={price} onChange={(e) => setPrice(e.target.value)} placeholder="Price"></Input>
            </div>
        </Modal >
    )
}