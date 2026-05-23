import { useNavigate } from "react-router-dom";
import { useCreateWorkoutTemplate } from "../hooks/useWorkoutTemplates";
import { useFieldArray, useForm } from "react-hook-form";
import type { CreateWorkoutTemplateFormData } from "../schemas/workout";
import {createWorkoutTemplateSchema} from "../schemas/workout"; 
import { zodResolver } from "@hookform/resolvers/zod";
import { toast } from "react-toastify";
import { FaTrashCan } from "react-icons/fa6";
import useExercises from "../hooks/useExercises";



const CreateWorkoutTemplateForm = () => {

  const navigate = useNavigate();

  const {data: exercises, isLoading, isError} = useExercises()

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
      <div className="shadow-lg flex flex-col overflow-hidden rounded-xl bg-white">
        <header className="relative flex items-center justify-center py-3 px-4  bg-red-300">
          <div className="text-3xl text-center w-full max-w-md">
            <input
              {...register("name")} 
              placeholder="Template Name"
              className="w-full text-center rounded-lg focus:outline-0"
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

        <div className="flex flex-col items-center">
          {fields.map((field, index) => (
            <div key={field.id} className="p-4 bg-gray-50 flex gap-4 items-end">
              
              <div className="flex-1">
                <label className="block text-xs text-gray-500 mb-1">Exercise</label>
                <select
                  {...register(`exercises.${index}.exerciseId`, { valueAsNumber: true })}
                  className="w-full p-2 border rounded"
                >
                  <option value="">{isLoading ? 'Loading exercises...' : 'Select exercise...'}</option>
                  {exercises?.map((ex) => (
                    <option key={ex.id} value={ex.id}>{ex.name}</option>
                  ))}
                </select>
                {errors.exercises?.[index]?.exerciseId && (
                  <p className="text-red-500 text-xs mt-1">
                    {errors.exercises[index]?.exerciseId?.message}
                  </p>
                )}
              </div>

              <div className="w-20">
                <label className="block text-xs text-gray-500 mb-1">Sets</label>
                <input
                  type="number"
                  {...register(`exercises.${index}.targetSets`, { valueAsNumber: true })}
                  className="w-full p-2 border rounded"
                />
              </div>

              <div className="w-20">
                <label className="block text-xs text-gray-500 mb-1">MinReps</label>
                <input
                  type="number"
                  {...register(`exercises.${index}.targetRepsMin`, { valueAsNumber: true })}
                  className="w-full p-2 border rounded"
                />
              </div>

              <div className="w-20">
                <label className="block text-xs text-gray-500 mb-1">MaxReps</label>
                <input
                  type="number"
                  {...register(`exercises.${index}.targetRepsMax`, { valueAsNumber: true })}
                  className="w-full p-2 border rounded"
                />
              </div>

              <div className="w-24">
                <label className="block text-xs text-gray-500 mb-1">Intensity</label>
                <input
                  {...register(`exercises.${index}.targetIntensity`)}
                  placeholder=""
                  className="w-full p-2 border rounded"
                />
              </div>

              <div className="w-24">
                <label className="block text-xs text-gray-500 mb-1">Rest</label>
                <input
                  {...register(`exercises.${index}.restSeconds`, {valueAsNumber: true})}
                  placeholder=""
                  className="w-full p-2 border rounded"
                />
              </div>

              <div className="mb-1.5">
                <FaTrashCan onClick={() => remove(index)} className="text-3xl text-red-400"/>
              </div>
            </div>
          ))}
          <div className="flex justify-between items-center">
            <button
              type="button"
              onClick={() => append({ 
                exerciseId: 0, targetSets: 0, targetRepsMin: 0, targetRepsMax:0, targetIntensity:"", restSeconds:0 })}
              className="px-4 py-2 bg-green-50 text-green-600 rounded-lg text-lg font-medium hover:bg-green-100 transition-colors"
            >
              + Add template exercise
            </button>
          </div>
          {fields.length === 0 && (
            <p className="text-gray-400 text-sm text-center py-4">No exercises added yet.</p>
          )}
        </div>

        <button
        type="submit"
        disabled={isPending}
        className="w-full py-2 text-xl text-white bg-green-800">
          {isPending ? 'Saving...' : 'Save'}
        </button>
      </div> 
    </form>
  );
};

export default CreateWorkoutTemplateForm