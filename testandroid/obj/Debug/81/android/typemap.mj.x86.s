	/* Data SHA1: 6d012af5dd0acccca1a95ca19382b903eed4affd */
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	5539
	/* entry-length */
	.long	253
	/* value-offset */
	.long	132
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 1401368
	.include	"typemap.mj.inc"
