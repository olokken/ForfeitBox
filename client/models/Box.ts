export type Box = {
  boxId: string;
  //osv
};

export type MinimalBox = {
  boxId: string;
  name: string;
  code: string;
};

export type CreateBoxRequest = {
  name: string;
};

export type JoinBoxRequest = {
  code: string;
};
