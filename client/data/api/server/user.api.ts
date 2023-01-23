import { User } from "../../models/User";
import { GET } from "./ajax";

export async function getUser(): Promise<User> {
  return await GET("/User");
}
