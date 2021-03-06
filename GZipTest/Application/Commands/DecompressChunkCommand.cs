using GZipTest.Application.Interfaces;

namespace GZipTest.Application.Commands
{
    public sealed class DecompressChunkCommand : ICommand
    {
        private readonly int _chunkIndex;
        private readonly IHolder _inputHolder;
        private readonly IHolder _outputHolder;
        private readonly ICompressor _compressor;

        public DecompressChunkCommand(int chuckIndex, IHolder inputHolder, IHolder outputHolder, ICompressor compressor)
        {
            _chunkIndex = chuckIndex;
            _inputHolder = inputHolder;
            _outputHolder = outputHolder;
            _compressor = compressor;
        }

        public void Execute()
        {
            _outputHolder.Add(_chunkIndex, _compressor.Decompress(_inputHolder.Get(_chunkIndex)));
        }
    }
}