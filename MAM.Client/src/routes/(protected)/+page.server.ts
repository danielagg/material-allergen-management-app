import { env } from '$env/dynamic/public';
import { superValidate } from 'sveltekit-superforms/client';
import { z } from 'zod';

export const load = async (): Promise<MaterialPageData> => {
	const form = await superValidate(createMaterialSchema);

	const response = await fetch(`${env.PUBLIC_BACKEND_URI}/api/allergens`);
	const materials = await response.json();

	return { form, materials };
};

export const actions = {
	createMaterial: async (event) => {
		const form = await superValidate(event, createMaterialSchema);
		const dto = {
			materialCode: form.data.code,
			shortMaterialName: form.data.shortName,
			fullMaterialName: form.data.fullName,
			materialTypeId: form.data.materialTypeId,
			unitOfMeasureCode: 'kg',
			unitOfMeasureName: 'Kilogram',
			initialStock: form.data.initialStock,
			allergensByNature: [],
			allergensByCrossContamination: []
		};

		await fetch(`${env.PUBLIC_BACKEND_URI}/api/allergens`, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(dto)
		});
	}
};

export type MaterialPageData = {
	form: any;
	materials: PaginatedMainListResult;
};

export type PaginatedMainListResult = {
	data: {
		materialCode: string;
		createdOn: string;
		shortName: string;
		fullName: string;
		hasAllergensByNature: boolean;
		hasAllergensByCrossContamination: boolean;
		materialType: string;
	}[];
	total: number;
	top: number;
	skip: number;
};

const createMaterialSchema = z.object({
	code: z.string(),
	shortName: z.string(),
	fullName: z.string(),
	materialTypeId: z.string(),
	additionalInformation: z.string(),
	unitOfMeasureId: z.string(),
	initialStock: z.number(),
	isAllergenByNature: z.boolean(),
	isAllergenByCrossContact: z.boolean(),
	allergensByNature: z.array(z.string())
});
