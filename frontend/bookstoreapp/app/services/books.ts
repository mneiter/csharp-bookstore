export interface BookRequest {
  title: string;
  description: string;
  price: number;
}

export const getAllBooks = async () => {
  const response = await fetch('http://localhost:5259/Books', {
    headers: { accept: 'text/plain', 'Content-Type': 'application/json' },
  });

  return response.json();
};

export const createBook = async (bookRequest: BookRequest) => {
  const response = await fetch('http://localhost:5259/Books', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(bookRequest),
  });

  return response.json();
};

export const updateBook = async (id: string, bookRequest: BookRequest) => {
  const response = await fetch(`http://localhost:5259/Books/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(bookRequest),
  });

  return response.json();
};

export const deleteBook = async (id: string) => {
  const response = await fetch(`http://localhost:5259/Books/${id}`, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
  });

  return response.json();
};
