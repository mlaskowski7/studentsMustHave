import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Student } from "../../lib/types";

export interface StudentState {
  student: Student | null;
}

const initialState: StudentState = {
  student: null,
};

export const studentSlice = createSlice({
  name: "student",
  initialState,
  reducers: {
    loadStudent: (state: StudentState, action: PayloadAction<Student>) => {
      state.student = action.payload;
    },
    clearStudent: (state) => {
      state.student = null;
    },
  },
});

export const { loadStudent, clearStudent } = studentSlice.actions;

export default studentSlice.reducer;
