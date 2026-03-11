// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/MNT/menu/MNT_121',
			name: 'menu-MNT_121',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_121/QMenuMnt121.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '121',
				baseArea: 'CATEGORY_TYPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/MNT/menu/MNT_111',
			name: 'menu-MNT_111',
			component: () => import('@/views/menus/ModuleMNT/MenuMNT_111/QMenuMnt111.vue'),
			meta: {
				routeType: 'menu',
				module: 'MNT',
				order: '111',
				baseArea: 'GROUP',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				isPopup: false
			}
		},
	]
}
