import { MinimalBox } from "./Box";

export type User = {
  userId: string;
  email: string;
  boxes: MinimalBox[];
};
