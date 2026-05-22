import { useNavigate } from "react-router-dom";
import { useCreateWorkoutTemplate } from "../hooks/useWorkoutTemplates";
import { useFieldArray, useForm } from "react-hook-form";
import type { CreateWorkoutTemplateFormData } from "../schemas/workout";
import {createWorkoutTemplateSchema} from "../schemas/workout"; 
import { zodResolver } from "@hookform/resolvers/zod";
import { toast } from "react-toastify";

const CreateWorkoutTemplateForm = () => {
  const navigate = useNavigate();

  const {mutateAsync: createTemplate, isPending } = useCreateWorkoutTemplate();
    
  const{ register, control, handleSubmit, formState: { errors }} = useForm<CreateWorkoutTemplateFormData>({
    resolver: zodResolver(createWorkoutTemplateSchema),
    defaultValues: {
      name: '',
      colorHex: '#3b82f6',
      exercises: []
    }
  });

  const { fields, append, remove } = useFieldArray({
    control,
    name: "exercises",
  })

  const handleFormSubmit = async (data: CreateWorkoutTemplateFormData) => {
    try {
      await toast.promise(
        createTemplate(data),
        {
          pending: 'Saving template...',
          success: 'Template created successfully!',
          error: 'Save failed. Please try again.'
        });
        navigate('/templates');
      } catch(error) {
        console.error("Mutation failed:", error);
      }
    };

  return (
    <form 
    onSubmit={handleSubmit(handleFormSubmit)} 
    className="flex justify-center">
      <div className="shadow-lg overflow-hidden rounded-xl bg-white">
        <header className="relative flex items-center justify-center py-3 px-4  bg-red-300">
          <div className="text-3xl text-center w-full max-w-md">
            <input
              {...register("name")} 
              placeholder="Template Name"
              className="w-full text-center rounded-lg"
            />
            {errors.name && <p className="text-red-400 text-sm mt-1 text-center font-medium">{errors.name.message}</p>}
          </div>

          <div className="absolute right-1 flex flex-col">
            <label htmlFor="color">
              Color
            </label>
            <select
            {...register("colorHex")}
            id="color"
            name="color"
            className="">
              <option value="#3b82f6">Blue</option>
              <option value="#ef4444">Red</option>
              <option value="#10b981">Green</option>
            </select>
          </div>
        </header>

        <div className="space-y-4">
          <div className="flex justify-between items-center">
            <button
              type="button"
              onClick={()=> console.log('Add new exercise clicked')}
              className="px-4 py-2 bg-blue-50 text-blue-600 rounded-lg text-sm font-medium hover:bg-blue-100 transition-colors"
            >
              + Add template exercise
            </button>
          </div>

          {"Exercises"}
          
          {fields.length === 0 && (
            <p className="text-gray-400 text-sm text-center py-4">No exercises added yet.</p>
          )}
        </div>
        <button
        type="submit"
        disabled={isPending}
        className="">
          {isPending ? 'Saving...' : 'Save'}
        </button>
      </div> 
    </form>
  );
};

export default CreateWorkoutTemplateForm