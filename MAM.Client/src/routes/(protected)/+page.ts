export async function load(): Promise<PaginatedMainListResult> {
	const response = await fetch('http://localhost:5156/api/allergens');
	return await response.json();
}

export type PaginatedMainListResult = {
	data: {
		id: string;
		createdOn: string;
		material: { id: string; name: string };
		hasAllergensByNature: boolean;
		hasAllergensByCrossContamination: boolean;
		materialType: string;
	}[];
	total: number;
	top: number;
	skip: number;
};
