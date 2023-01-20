import { headers } from "next/headers";

export const GET = async (uri: string) => {
  const token: string | null = headers().get("Authorization");
  if (token == null) {
    throw new Error("User has no token");
  }

  const response: Response = await fetch(`${process.env.BASE_URL}${uri}`, {
    method: "GET",
    headers: {
      Authorization: token,
    },
  });

  if (!response.ok) {
    throw new Error("Failed to fetch data from API");
  }
  return response.json();
};

export const POST = async (uri: string, body: string) => {
  const token: string | null = headers().get("Authorization");
  if (token == null) {
    throw new Error("User has no token");
  }

  const response: Response = await fetch(`${process.env.BASE_URL}${uri}`, {
    method: "POST",
    headers: {
      Authorization: token,
    },
    body: body,
  });

  if (!response.ok) {
    throw new Error("Failed to post data to the API");
  }
  return response.json();
};
