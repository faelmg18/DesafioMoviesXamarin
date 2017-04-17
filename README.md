

# ZupDesafioMovies
Projeto criado para participar do processo seletivo Zup
## Omdb
A API OMDb é um serviço gratuito na web para obter informações de filmes, todos os conteúdos e imagens no site são contribuídos e mantidos por seus usuários, você pode ver mais em
[OmbdApi](http://www.omdbapi.com/) - The Open Movie Database.

## APK
Para ver o aplicativo funcionando, baixe no link
[DesafioZup APK](https://drive.google.com/open?id=0BwLShtZOjYrbMlNyaHNBUlhDREk)

### Pré-requisitos


Android SKD 21, 5.0 ou superior

 * Android (Mínimo 5.0)

## Pagina Incial
### Meus Filmes
#### Aqui são listados todos os filmes salvos em no dispositivo através do menu de Busca Filmes
![screenshot_20170405-161940](https://cloud.githubusercontent.com/assets/8068428/24724363/38baffb6-1a21-11e7-8e4a-32432d6d45ce.png)


## Buscando todos os filmes salvos no dispositivos
Para buscar os filmes já salvos no dispositivo, o método retrieveAllGroupBy() da classe MovieDAO deve ser chamado, sendo assim irá retornar todos os filmes separados por categoria dos filmes.

```
Exemplos
  
   MovieRepository movieRepository = RepositoryFactory.getInstance().createMoviesRepository();
   LinkedHashMap<String, ArrayList<Movie>> hasMapMovies = movieRepository.retrieveAllGroupBy();
   
   ### Colocando em um Adapter
   CategorizedMoviesAdapter mAdapter = new CategorizedMoviesAdapter(getActivity())
   
   for (String key : hasMapMovies.keySet()) {
            mAdapter.addMovies(new CategorizedMovies(hasMapMovies.get(key), key));
        }
        
        recyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
        recyclerView.setHasFixedSize(true);
        recyclerView.setItemAnimator(new DefaultItemAnimator());
        recyclerView.setAdapter(mAdapter);
   
  
```
![ezgif com-video-to-gif](https://cloud.githubusercontent.com/assets/8068428/24764064/9636ad9a-1ac9-11e7-946f-4facd16e6abc.gif)


### Mostrando detalhes do filme

Para mostrar o detalhes do filme é possível clicar em qualquer um dos filmes da lista, sendo assim é chamada a tela onde se mostra os detalhes.

![ezgif com-video-to-gif](https://cloud.githubusercontent.com/assets/8068428/24725001/a8b74124-1a23-11e7-830f-f8cf80e61935.gif)


### Deletando o filme da minha lista de filmes


Para deletar o filme é necessário clicar no botão com uma lixeira no lado direito da tela.
logo após o evento ser acionado, é chamado o método  movieRepository.delete(movie) passando como parâmetro o filme a ser deletado;


```
MovieRepository movieRepository = RepositoryFactory.getInstance().createMoviesRepository();

   if(movie != null){
                    DialogBuilder.showDialogPositiveNegative(MovieDetail.this, getString(R.string.stringEmpty), getString(R.string.remove_movie), new DialogBuilder.ButtonCallback() {
                        @Override
                        protected void onPositive(AlertDialog.Builder builder, DialogInterface dialogInterface) {
                            movieRepository.delete(movie);
                            setResult(RESULT_OK);
                            finish();
                            Toast.makeText(MovieDetail.this, R.string.deleted_movie_successfully,Toast.LENGTH_LONG).show();
                        }

                        @Override
                        protected void onNegative(AlertDialog.Builder builder, DialogInterface dialogInterface) {
                            dialogInterface.dismiss();
                        }
                    });
                }
```

![ezgif com-video-to-gif 1](https://cloud.githubusercontent.com/assets/8068428/24725376/161b1316-1a25-11e7-9221-e3e9b5079785.gif)


## Buscando filmes no dispositivo pelo título.

É possível buscar um filme no celular mesmo que não tenha internet, mas o filme já deve estar salvo nos meus filmes.

```
 MovieRepository movieRepository = RepositoryFactory.getInstance().createMoviesRepository();
 List<Movie> movies = movieRepository.retrieveAllByName(movieTitle);

```

![ezgif com-video-to-gif 1](https://cloud.githubusercontent.com/assets/8068428/24764200/f46a0704-1ac9-11e7-8430-7ceb58e1d35b.gif)

### Buscando filme da api Omdb

Para buscar um filme da api omdb é necessário instanciar a classe OmdbApi que foi criada por mim para esse projeto.
A classe faz a chamada da Api Omdb passando como parâmetro na url o nome do filme.

```
Exemplo da chamada OmdbApi
http://www.omdbapi.com/?t=ice

```
```
Exemplo da chamada através da api criada
OmdbApi omdbApi = new OmdbApi(getActivity());

 omdbApi.findMovie(movieTitle, new OmdApiFinderImp() {
                    @Override
                    public void onFindMovie(Movie movie) {
                        loadMovieToViewScreen((movie));
                    }

                    @Override
                    public void onError(Exception e) {
                        DialogBuilder.showErrorServerInformation(getContext());
                    }
                });
```
![ezgif com-video-to-gif 2](https://cloud.githubusercontent.com/assets/8068428/24764385/91cb94a4-1aca-11e7-9519-4b6d9580854d.gif)
## Contribuições

* **Jackson Core databind** - [jackson-databind](https://mvnrepository.com/artifact/com.fasterxml.jackson.core/jackson-databind/2.0.1)
* **Jackson Core annotations** - [jackson-annotations](https://mvnrepository.com/artifact/com.fasterxml.jackson.core/jackson-annotations/2.2.1)
* **Universal Image Loader** -  [Universal-Image-Loader](https://github.com/nostra13/Android-Universal-Image-Loader)

## Autor

* **Rafael Henrique Fernandes** - [Rafael Fernandes](https://github.com/faelmg18)

## Licença

Este projeto é licenciado sob a licença MIT - consulte o arquivo [LICENSE.md](LICENSE.md) para obter detalhes


