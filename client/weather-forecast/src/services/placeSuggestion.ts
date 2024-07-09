export const fetchCities = async (search: string) => {
  const url = `https://api.mapbox.com/search/geocode/v6/forward?q=${search}&country=vn&proximity=ip&language=en&access_token=pk.eyJ1IjoiYnJ1Y2VsZWUyMTExIiwiYSI6ImNsdzh4NmJhYjJudnoya3RpOHNyZzBqdHgifQ.aCl2uTLhbY0KMVgmS0enBQ`;
  const res = await (
    await fetch(url, {
      method: 'GET',
      // body: JSON.stringify({
      //   query: search,
      //   type: 'city',
      //   language: 'en',
      // }),
    })
  ).json();

  return res.features.map((item: any) => {
    return {
      name: item.properties.full_address,
      lat: item.properties.coordinates.latitude,
      lon: item.properties.coordinates.longitude,
    };
  });

  // return res.hits
  //   .filter((item: any) => item.is_city)
  //   .map((i: any) => {
  //     return i.locale_names[0] + ', ' + i.country;
  //   });
};
